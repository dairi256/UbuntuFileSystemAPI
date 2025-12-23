using System.Runtime.CompilerServices;

namespace UbuntuFileSystemAPI.Services
{
    public class LocalFileService(IConfiguration config) : IFileService
    {
        private readonly string _storagePath = config["FileStorage:StoragePath"]
                                               ?? throw new Exception("Your storage path has not been configured.");

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if (!Directory.Exists(_storagePath)) // Important if the directory doesn't exist
            {
                Directory.CreateDirectory(_storagePath);
            }

            var trustedFilename = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var fullPath = Path.Combine(_storagePath, trustedFilename);

            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return trustedFilename;
        }

        public IEnumerable<string> ListFiles()
        {
            if (!Directory.Exists(_storagePath))
            {
                return Enumerable.Empty<string>();
            }
            return Directory.GetFiles(_storagePath).Select(Path.GetFileName);
        }

        public async Task<(byte[] bytes, string fileName)> GetFileAsync(string fileName)
        {
            var path = Path.Combine(_storagePath, fileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", fileName);
            }
            var bytes = await File.ReadAllBytesAsync(path);
            return (bytes, fileName);
        }
    }
}

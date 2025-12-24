using System.Runtime.CompilerServices;
using UbuntuFileSystemAPI.Data;
using UbuntuFileSystemAPI.Models;

namespace UbuntuFileSystemAPI.Services
{
    public class LocalFileService: IFileService
    {
        private readonly string _storagePath;
        private readonly AppDbContext _context;

        public LocalFileService(IConfiguration config, AppDbContext context)
        {
            _storagePath = config["FileStorage:StoragePath"] ?? "uploads";
            _context = context;

            if (!Directory.Exists(_storagePath)) Directory.CreateDirectory(_storagePath);
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {

            var untrustedFilename = Path.GetFileName(file.FileName);
            var storedFilename = $"{Guid.NewGuid()}_{untrustedFilename}";
            var fullPath = Path.Combine(_storagePath, storedFilename);

            if (!Directory.Exists(_storagePath)) // Important if the directory doesn't exist
            {
                Directory.CreateDirectory(_storagePath);
            }


            using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            var fileRecord = new FileRecord
            {
                FileName = storedFilename,
                OriginalName = untrustedFilename,
                SizeInBytes = file.Length,
                UploadDate = DateTime.UtcNow
            };

            _context.Files.Add(fileRecord);
            await _context.SaveChangesAsync(); // Pushes data to database
            return storedFilename;
        }

        public IEnumerable<FileRecord> ListFiles()
        {
            if (!Directory.Exists(_storagePath))
            {
                return Enumerable.Empty<FileRecord>();
            }
            return _context.Files.OrderByDescending(f => f.UploadDate).ToList();
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

        public bool DeleteFile(string fileName)
        {
            var filePath = Path.Combine(_storagePath, fileName);

            if (File.Exists(filePath))
                {
                File.Delete(filePath);

                var record = _context.Files.FirstOrDefault(f => f.FileName == fileName);
                if (record != null)
                {
                    _context.Files.Remove(record);
                    _context.SaveChanges();
                }
                return true;
            }

            return false;
        }
    }
}

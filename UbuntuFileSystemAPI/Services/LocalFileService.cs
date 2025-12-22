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
    }
}

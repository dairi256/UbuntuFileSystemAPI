using UbuntuFileSystemAPI.Models;

namespace UbuntuFileSystemAPI.Services
{
    public interface IFileService // Interface for file services
    {
        Task<string> SaveFileAsync(IFormFile file);

        IEnumerable<FileRecord> ListFiles();

        Task<(byte[] bytes, string fileName)> GetFileAsync(string fileName);

        bool DeleteFile(string fileName);

    }
}

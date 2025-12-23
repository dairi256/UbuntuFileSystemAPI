namespace UbuntuFileSystemAPI.Services
{
    public interface IFileService // Interface for file services
    {
        Task<string> SaveFileAsync(IFormFile file);

        IEnumerable<string> ListFiles();

        Task<(byte[] bytes, string fileName)> GetFileAsync(string fileName);
    }
}

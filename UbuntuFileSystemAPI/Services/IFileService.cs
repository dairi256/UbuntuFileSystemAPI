namespace UbuntuFileSystemAPI.Services
{
    public interface IFileService // Interface for file services
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UbuntuFileSystemAPI.Services;

namespace UbuntuFileSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(IFileService fileService) : ControllerBase
    {
        private readonly IFileService _fileService;

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0) // Basic validation if a file has been uploaded
            {
                return BadRequest("No file has been uploaded");
            }

            try
            {
                var fileName = await fileService.SaveFileAsync(file);

                return Ok(new { Message = "Upload successful!", FileName = fileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("list")]
        public IActionResult ListFiles()
        {
            try
            {
                var files = fileService.ListFiles();
                return Ok(files);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            } // Error just in case something goes wrong
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult>Download(string fileName)
        {
            try
            {
                var (bytes, name) = await fileService.GetFileAsync(fileName);
                return File(bytes, "application/octet-stream", name);
            }
            catch (FileNotFoundException)
            {
                return NotFound("File not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{fileName}")]
        public IActionResult DeleteFile(string fileName)
        {
            try
            {
                var result = _fileService.DeleteFile(fileName);

                if (result)
                {
                    return Ok(new { Message = "File deleted successfully." });
                }
                else
                {
                    return NotFound("File not found on the server.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

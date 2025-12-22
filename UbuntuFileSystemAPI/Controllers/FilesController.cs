using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UbuntuFileSystemAPI.Services;

namespace UbuntuFileSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController(IFileService fileService) : ControllerBase
    {

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
    }
}

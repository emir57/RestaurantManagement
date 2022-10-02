using Microsoft.AspNetCore.Mvc;
using Services.Image.API.Extensions;
using Services.Image.API.Messages;

namespace Services.Image.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly string IMAGE_PATH = string.Empty;
        private readonly IConfiguration _configuration;
        public ImagesController(IConfiguration configuration)
        {
            _configuration = configuration;
            IMAGE_PATH = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("ImageUploadPath").Value);
        }
        [HttpPost]
        public async Task<IActionResult> ImageSave(IFormFile image, [FromQuery] string productId, CancellationToken cancellationToken)
        {
            (bool result, string message) body = await image.UploadAsync(IMAGE_PATH, productId);
            if (body.result == false)
                return BadRequest(body.message);

            return Ok(body.message);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> ImageDelete(string productId)
        {
            (bool result, string message) body = await productId.DeleteAsync(IMAGE_PATH);

            if (body.result == false)
                return BadRequest(body.message);

            return NoContent();
        }

        [HttpGet("{productId}")]
        public IActionResult GetImage(string productId)
        {
            string fileName = $"{productId}.png";
            var path = Path.Combine(IMAGE_PATH, fileName);

            if (System.IO.File.Exists(path) == false)
            {
                return BadRequest(ImageMessages.ImageNotFound);
            }

            string url = $"http://localhost:5014/Images/{productId}.png";
            return Ok(url);
        }

        private async Task<string> uploadAsync(IFormFile image, string productId, string extension, CancellationToken cancellationToken = default)
        {
            string newFileName = string.Format("{0}{1}", productId, extension);
            string path = Path.Combine(IMAGE_PATH, newFileName);

            using var stream = new FileStream(path, FileMode.Create);
            await image.CopyToAsync(stream, cancellationToken);
            await stream.FlushAsync();

            return newFileName;
        }
    }
}

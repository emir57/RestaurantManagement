using Microsoft.AspNetCore.Mvc;
using Services.Image.API.Extensions;

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
            IMAGE_PATH = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("ImageSettings:UploadPath").Value);
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
        public async Task<IActionResult> GetImage(string productId)
        {
            (bool result, string message) body 
                = await productId.GetAsync(IMAGE_PATH, _configuration.GetSection("ImageSettings:GetPath").Value);

            if (body.result == false)
                return BadRequest(body.message);

            return Ok(body.message);
        }
    }
}

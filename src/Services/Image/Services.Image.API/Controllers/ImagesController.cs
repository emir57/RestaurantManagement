using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Image.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ImageSave(IFormFile image, [FromQuery] string productId, CancellationToken cancellationToken)
        {
            if (image != null && image.Length > 0)
            {
                var extention = Path.GetExtension(image.FileName);

                if (extention != ".png")
                {
                    return BadRequest("Image should be .png");
                };

                var newFileName = productId + extention;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream, cancellationToken);
                }
                //asd
                var returnPath = "Images/" + newFileName;

                return Ok(returnPath);
            }
            return BadRequest("Image is empty");
        }

        [HttpDelete("{productId}")]
        public IActionResult ImageDelete(string productId)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", ($"{productId}.png"));
            if (!System.IO.File.Exists(path))
            {
                return BadRequest("Image not found!");
            }

            System.IO.File.Delete(path);
            return NoContent();
        }

        [HttpGet("{productId}")]
        public IActionResult GetImage(string productId)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", ($"{productId}.png"));
            if (!System.IO.File.Exists(path))
            {
                return BadRequest("Image not found!");
            }

            return Ok("http://localhost:5014/Images/" + $"{productId}.png");
        }
    }
}

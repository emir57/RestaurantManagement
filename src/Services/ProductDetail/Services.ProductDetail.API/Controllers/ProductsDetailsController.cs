using Microsoft.AspNetCore.Mvc;
using Services.ProductDetail.Application.Features.ProductDetail.Command.CreateProductsDetail;

namespace Services.ProductDetail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductsDetailCommand createProductsDetailCommand)
        {
            await Mediator.Send(createProductsDetailCommand);
            return NoContent();
        }

    }
}

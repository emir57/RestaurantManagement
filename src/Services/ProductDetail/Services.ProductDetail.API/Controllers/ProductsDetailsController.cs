using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProductDetail.Application.Features.ProductDetail.Command.CreateProductsDetail;
using System.ComponentModel;

namespace Services.ProductDetail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddingNew(CreateProductsDetailCommand createProductsDetailCommand)
        {
            var result = await Mediator.Send(createProductsDetailCommand);
            return Ok(result);
        }

    }
}

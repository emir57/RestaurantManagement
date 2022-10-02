using Microsoft.AspNetCore.Mvc;
using Services.ProductDetail.Application.Features.ProductDetail.Commands.CreateProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Commands.DeleteProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Commands.UpdateProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Features.ProductDetail.Models;
using Services.ProductDetail.Application.Features.ProductDetail.Queries.GetAllProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Queries.GetByIdProductsDetail;

namespace Services.ProductDetail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllProductsDetailQuery request = new();
            ListReadProductsDetailModel listReadProductsDetailModel = await Mediator.Send(request);
            return Ok(listReadProductsDetailModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            GetByIdProductsDetailQuery getByIdProductsDetailQuery = new(id);
            ReadProductsDetailDto readProductsDetailDto = await Mediator.Send(getByIdProductsDetailQuery);
            return Ok(readProductsDetailDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductsDetailCommand createProductsDetailCommand)
        {
            await Mediator.Send(createProductsDetailCommand);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateProductsDetailCommand updateProductsDetailCommand)
        {
            updateProductsDetailCommand.Id = id;
            await Mediator.Send(updateProductsDetailCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            DeleteProductsDetailCommand deleteProductsDetailCommand = new(id);
            await Mediator.Send(deleteProductsDetailCommand);
            return NoContent();
        }

    }
}

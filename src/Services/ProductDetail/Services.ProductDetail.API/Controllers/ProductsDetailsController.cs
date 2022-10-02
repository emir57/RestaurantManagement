using Microsoft.AspNetCore.Mvc;
using Services.ProductDetail.Application.Features.ProductDetail.Commands.CreateProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Commands.DeleteProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Commands.UpdateProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Features.ProductDetail.Queries.GetAllProductsDetail;
using Services.ProductDetail.Application.Features.ProductDetail.Queries.GetByIdProductsDetail;

namespace Services.ProductDetail.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : BaseController
    {
        [HttpGet("get/byid")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductsDetailQuery getByIdProductsDetailQuery)
        {
            ReadProductsDetailDto readProductsDetailDto = await Mediator.Send(getByIdProductsDetailQuery);
            return Ok(readProductsDetailDto);
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAll()
        {
            ListReadProductsDetailDto listReadProductsDetailDto = await Mediator.Send(new GetAllProductsDetailQuery());
            return Ok(listReadProductsDetailDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreateProductsDetailCommand createProductsDetailCommand)
        {
            await Mediator.Send(createProductsDetailCommand);
            return NoContent();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromQuery] string id, [FromBody] WriteProductsDetailDto writeProductsDetailDto)
        {
            UpdateProductsDetailCommand updateProductsDetailCommand = new() { Id = id, WriteProductsDetailDto = writeProductsDetailDto };
            await Mediator.Send(updateProductsDetailCommand);
            return NoContent();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductsDetailCommand deleteProductsDetailCommand)
        {
            await Mediator.Send(deleteProductsDetailCommand);
            return NoContent();
        }

    }
}

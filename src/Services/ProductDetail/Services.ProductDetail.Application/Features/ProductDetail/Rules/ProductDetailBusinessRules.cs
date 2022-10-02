using Services.ProductDetail.Application.Features.ProductDetail.Constants;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Services;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Rules
{
    public class ProductDetailBusinessRules
    {
        private readonly IProductDetailService _productDetailService;
        private readonly ProductDetailBusinessRulesMessages _messages;

        public ProductDetailBusinessRules(ProductDetailBusinessRulesMessages messages, 
                                          IProductDetailService productDetailService)
        {
            _messages = messages;
            _productDetailService = productDetailService;
        }

        public async Task ProductsDetailNameShouldNotBeAlreadyExistWhenProductsDetailCreated(string name)
        {

        }

        public async Task ProductsDetailNameShouldNotBeAlreadyExistWhenProductsDetailUpdated(string name)
        {

        }

        public async Task AllProductExtrasShouldBeAlreadyExistWhenProductsDetailCreated(ICollection<WriteProductExtrasDto> productExtras)
        {

        }

        public async Task ProductsDetailShouldBeExistsWhenRequestedWithId(string id)
        {
            ProductsDetail productsDetail = await _productDetailService.GetAsync(p => p.Id == id);

            if (productsDetail == null) ; //Need to throw after core exception created.
        }
    }
}

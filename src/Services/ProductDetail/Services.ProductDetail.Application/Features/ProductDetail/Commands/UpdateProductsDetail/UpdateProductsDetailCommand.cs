using AutoMapper;
using MediatR;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Features.ProductDetail.Rules;
using Services.ProductDetail.Application.Services;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Commands.UpdateProductsDetail
{
    public class UpdateProductsDetailCommand : IRequest<UpdatedProductsDetailDto>
    {
        public string? Id { get; set; }
        public WriteProductsDetailDto WriteProductsDetailDto { get; set; }

        public class UpdateProductsDetailCommandHandler : IRequestHandler<UpdateProductsDetailCommand, UpdatedProductsDetailDto>
        {
            private readonly IProductDetailService _productDetailService;
            private readonly IMapper _mapper;
            private readonly ProductDetailBusinessRules _productDetailBusinessRules;

            public UpdateProductsDetailCommandHandler(IProductDetailService productDetailService,
                                                      IMapper mapper, 
                                                      ProductDetailBusinessRules productDetailBusinessRules)
            {
                _productDetailService = productDetailService;
                _mapper = mapper;
                _productDetailBusinessRules = productDetailBusinessRules;
            }

            public async Task<UpdatedProductsDetailDto> Handle(UpdateProductsDetailCommand request, CancellationToken cancellationToken)
            {
                //rules needs to be fill
                await _productDetailBusinessRules.ProductsDetailShouldBeExistsWhenRequestedWithId(request.Id);
                await _productDetailBusinessRules.ProductsDetailNameShouldNotBeAlreadyExistWhenProductsDetailUpdated(request.WriteProductsDetailDto.Name);
                await _productDetailBusinessRules.AllProductExtrasShouldBeAlreadyExistWhenProductsDetailCreated(request.WriteProductsDetailDto.ProductExtras);

                ProductsDetail productsDetail = _mapper.Map<ProductsDetail>(request.WriteProductsDetailDto);
                productsDetail.Id = request.Id;

                await _productDetailService.UpdateAsync(productsDetail);

                return new();
            }
        }
    }
}

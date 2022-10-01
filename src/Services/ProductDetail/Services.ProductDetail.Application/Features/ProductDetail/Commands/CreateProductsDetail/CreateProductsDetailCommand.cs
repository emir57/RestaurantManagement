using AutoMapper;
using MediatR;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Services;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Commands.CreateProductsDetail
{
    public class CreateProductsDetailCommand : IRequest<CreatedProductsDetail>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public class CreateProductsDetailCommandHandler : IRequestHandler<CreateProductsDetailCommand, CreatedProductsDetail>
        {
            private readonly IProductDetailService _productDetailService;
            private readonly IMapper _mapper;

            public CreateProductsDetailCommandHandler(IProductDetailService productDetailService, IMapper mapper)
            {
                _productDetailService = productDetailService;
                _mapper = mapper;
            }

            public async Task<CreatedProductsDetail> Handle(CreateProductsDetailCommand request, CancellationToken cancellationToken)
            {
                ProductsDetail productsDetail = _mapper.Map<ProductsDetail>(request);
                await _productDetailService.AddAsync(productsDetail);

                return new();
            }
        }
    }
}

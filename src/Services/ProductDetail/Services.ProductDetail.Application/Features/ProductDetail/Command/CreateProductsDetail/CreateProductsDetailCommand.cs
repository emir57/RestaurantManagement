using MediatR;
using Services.ProductDetail.Application.Services;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Command.CreateProductsDetail
{
    public class CreateProductsDetailCommand : IRequest<string>
    {
        public ProductsDetail ProductsDetail { get; set; }
        public class CreateProductsDetailCommandHandler : IRequestHandler<CreateProductsDetailCommand, string>
        {
            private readonly IProductDetailService _productDetailService;

            public CreateProductsDetailCommandHandler(IProductDetailService productDetailService)
            {
                _productDetailService = productDetailService;
            }

            public async Task<string> Handle(CreateProductsDetailCommand request, CancellationToken cancellationToken)
            {
                await _productDetailService.AddAsync(request.ProductsDetail);

                return "asd";
            }
        }
    }
}

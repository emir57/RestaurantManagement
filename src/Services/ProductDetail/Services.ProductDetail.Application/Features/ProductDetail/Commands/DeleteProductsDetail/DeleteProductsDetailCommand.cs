using AutoMapper;
using MediatR;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Features.ProductDetail.Rules;
using Services.ProductDetail.Application.Services;

namespace Services.ProductDetail.Application.Features.ProductDetail.Commands.DeleteProductsDetail
{
    public class DeleteProductsDetailCommand : IRequest<DeletedProductsDetailDto>
    {
        public string Id { get; set; }
        public DeleteProductsDetailCommand(string id)
        {
            Id = id;
        }
        public DeleteProductsDetailCommand() { }

        public class DeleteProductsDetailCommandHandler : IRequestHandler<DeleteProductsDetailCommand, DeletedProductsDetailDto>
        {
            private readonly IProductDetailService _productDetailService;
            private readonly IMapper _mapper;
            private readonly ProductDetailBusinessRules _productDetailBusinessRules;

            public DeleteProductsDetailCommandHandler(IProductDetailService productDetailService,
                                                      IMapper mapper,
                                                      ProductDetailBusinessRules productDetailBusinessRules)
            {
                _productDetailService = productDetailService;
                _mapper = mapper;
                _productDetailBusinessRules = productDetailBusinessRules;
            }

            public async Task<DeletedProductsDetailDto> Handle(DeleteProductsDetailCommand request, CancellationToken cancellationToken)
            {
                //rules needs to be fill
                await _productDetailBusinessRules.ProductsDetailShouldBeExistsWhenRequestedWithId(request.Id);

                await _productDetailService.DeleteAsync(request.Id);

                return new();
            }
        }
    }
}

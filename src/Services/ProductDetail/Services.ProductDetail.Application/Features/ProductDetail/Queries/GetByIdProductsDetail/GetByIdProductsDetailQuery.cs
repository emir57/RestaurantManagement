using AutoMapper;
using MediatR;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Features.ProductDetail.Rules;
using Services.ProductDetail.Application.Services;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Queries.GetByIdProductsDetail
{
    public class GetByIdProductsDetailQuery : IRequest<ReadProductsDetailDto>
    {
        public string Id { get; set; }

        public class GetByIdProductsDetailQueryHandler : IRequestHandler<GetByIdProductsDetailQuery, ReadProductsDetailDto>
        {
            private readonly IProductDetailService _productDetailService;
            private readonly IMapper _mapper;
            private readonly ProductDetailBusinessRules _productDetailBusinessRules;

            public GetByIdProductsDetailQueryHandler(IProductDetailService productDetailService, 
                                                     IMapper mapper, 
                                                     ProductDetailBusinessRules productDetailBusinessRules)
            {
                _productDetailService = productDetailService;
                _mapper = mapper;
                _productDetailBusinessRules = productDetailBusinessRules;
            }

            public async Task<ReadProductsDetailDto> Handle(GetByIdProductsDetailQuery request, CancellationToken cancellationToken)
            {
                await _productDetailBusinessRules.ProductsDetailShouldBeExistsWhenRequestedWithId(request.Id);

                ProductsDetail productsDetail = await _productDetailService.GetAsync(p => p.Id == request.Id);
                ReadProductsDetailDto readProductsDetailDto = _mapper.Map<ReadProductsDetailDto>(productsDetail);

                return readProductsDetailDto;
            }
        }
    }
}

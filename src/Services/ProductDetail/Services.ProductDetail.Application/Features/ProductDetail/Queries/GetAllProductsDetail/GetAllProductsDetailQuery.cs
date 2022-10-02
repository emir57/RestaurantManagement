using AutoMapper;
using MediatR;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Features.ProductDetail.Rules;
using Services.ProductDetail.Application.Services;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Queries.GetAllProductsDetail
{
    public class GetAllProductsDetailQuery : IRequest<ListReadProductsDetailDto>
    {
        public class GetAllProductsDetailQueryHandler : IRequestHandler<GetAllProductsDetailQuery, ListReadProductsDetailDto>
        {
            private readonly IProductDetailService _productDetailService;
            private readonly IMapper _mapper;
            private readonly ProductDetailBusinessRules _productDetailBusinessRules;

            public GetAllProductsDetailQueryHandler(IProductDetailService productDetailService, 
                                                    IMapper mapper, 
                                                    ProductDetailBusinessRules productDetailBusinessRules)
            {
                _productDetailService = productDetailService;
                _mapper = mapper;
                _productDetailBusinessRules = productDetailBusinessRules;
            }

            public async Task<ListReadProductsDetailDto> Handle(GetAllProductsDetailQuery request, CancellationToken cancellationToken)
            {
                IList<ProductsDetail> listProductsDetail = await _productDetailService.GetListWithNoDeletedAsync();

                await _productDetailBusinessRules.ThereShouldBeSomeProductsDetailDataAsRequested(listProductsDetail);

                ListReadProductsDetailDto listReadProductsDetailDto = _mapper.Map<ListReadProductsDetailDto>(listProductsDetail);

                return listReadProductsDetailDto;
            }
        }
    }
}

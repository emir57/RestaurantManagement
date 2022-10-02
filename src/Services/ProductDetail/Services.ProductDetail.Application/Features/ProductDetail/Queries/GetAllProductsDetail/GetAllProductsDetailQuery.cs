using AutoMapper;
using MediatR;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Application.Features.ProductDetail.Models;
using Services.ProductDetail.Application.Features.ProductDetail.Rules;
using Services.ProductDetail.Application.Services;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Queries.GetAllProductsDetail
{
    public class GetAllProductsDetailQuery : IRequest<ListReadProductsDetailModel>
    {
        public class GetAllProductsDetailQueryHandler : IRequestHandler<GetAllProductsDetailQuery, ListReadProductsDetailModel>
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

            public async Task<ListReadProductsDetailModel> Handle(GetAllProductsDetailQuery request, CancellationToken cancellationToken)
            {
                List<ProductsDetail> listProductsDetail = await _productDetailService.GetListWithNoDeletedAsync();

                //await _productDetailBusinessRules.ThereShouldBeSomeProductsDetailDataAsRequested(listProductsDetail);

                ListReadProductsDetailModel model = new()
                {
                    Items = _mapper.Map<List<ReadProductsDetailDto>>(listProductsDetail)
                };

                return model;
            }
        }
    }
}

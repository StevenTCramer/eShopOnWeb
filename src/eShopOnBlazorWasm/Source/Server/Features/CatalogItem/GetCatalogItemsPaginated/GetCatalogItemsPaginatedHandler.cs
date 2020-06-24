namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using AutoMapper;
  using MediatR;
  using Microsoft.eShopWeb.ApplicationCore.Interfaces;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.eShopWeb.ApplicationCore.Entities;
  using System.Threading;
  using System.Threading.Tasks;
  using Microsoft.eShopWeb.ApplicationCore.Specifications;
  using System;

  public class GetCatalogItemsPaginatedHandler : 
    IRequestHandler<GetCatalogItemsPaginatedRequest, GetCatalogItemsPaginatedResponse>
  {

    public GetCatalogItemsPaginatedHandler(IAsyncRepository<CatalogItem> aCatalogItemRepository, 
      IMapper aMapper,
      IUriComposer aUriComposer)
    {
      CatalogItemRepository = aCatalogItemRepository;
      Mapper = aMapper;
      UriComposer = aUriComposer;
    }

    public IAsyncRepository<CatalogItem> CatalogItemRepository { get; }
    public IMapper Mapper { get; }
    public IUriComposer UriComposer { get; }

    public async Task<GetCatalogItemsPaginatedResponse> Handle
    (
      GetCatalogItemsPaginatedRequest aGetCatalogItemsPaginatedRequest,
      CancellationToken aCancellationToken
    )
    {
      var catalogFilterPaginatedSpecification =
        new CatalogFilterPaginatedSpecification
        (
          skip: aGetCatalogItemsPaginatedRequest.PageSize * aGetCatalogItemsPaginatedRequest.PageIndex, 
          take: aGetCatalogItemsPaginatedRequest.PageSize,
          brandId: aGetCatalogItemsPaginatedRequest.CatalogBrandId,
          typeId: aGetCatalogItemsPaginatedRequest.CatalogTypeId
        );
      IReadOnlyList<CatalogItem> catalogItems = await CatalogItemRepository.ListAsync(catalogFilterPaginatedSpecification);
      var filterSpecification = new CatalogFilterSpecification(
        aGetCatalogItemsPaginatedRequest.CatalogBrandId, 
        aGetCatalogItemsPaginatedRequest.CatalogTypeId);
      int totalItems = await CatalogItemRepository.CountAsync(filterSpecification);

      var response = new GetCatalogItemsPaginatedResponse(aGetCatalogItemsPaginatedRequest.CorrelationId)
      {
        CorrelationId = aGetCatalogItemsPaginatedRequest.CorrelationId,
        PageCount = int.Parse(Math.Ceiling((decimal)totalItems / aGetCatalogItemsPaginatedRequest.PageSize).ToString())
      };

      response.CatalogItems.AddRange(catalogItems.Select(Mapper.Map<CatalogItemDto>));
      foreach (CatalogItemDto item in response.CatalogItems)
      {
        item.PictureUri = UriComposer.ComposePicUri(item.PictureUri);
      }

      return response;
    }
  }
}

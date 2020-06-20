namespace eShopOnBlazorWasm.Features.CatalogItems.Components
{
  using eShopOnBlazorWasm.Features.Bases;
  using eShopOnBlazorWasm.Features.CatalogBrands;
  using eShopOnBlazorWasm.Features.CatalogItems;
  using eShopOnBlazorWasm.Features.CatalogTypes;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public partial class Edit : BaseComponent
  {
    public UpdateCatalogItemRequest UpdateCatalogItemRequest { get; set; }

    private IReadOnlyList<CatalogBrandDto> CatalogBrands => CatalogBrandState.CatalogBrandsAsList;
    private IReadOnlyList<CatalogTypeDto> CatalogTypes => CatalogTypeState.CatalogTypesAsList;

    [Parameter] public int CatalogItemId { get; set; }
    [Parameter] public string RedirectRoute { get; set; }

    protected override Task OnInitializedAsync()
    {
      CatalogItemDto catalogItem = CatalogItemState.CatalogItems[CatalogItemId];
      UpdateCatalogItemRequest = new UpdateCatalogItemRequest();

      MapToRequest(catalogItem);

      return base.OnInitializedAsync();
    }

    private void MapToRequest(CatalogItemDto catalogItem)
    {
      // TODO: consider Automapper here
      UpdateCatalogItemRequest.CatalogBrandId = catalogItem.CatalogBrandId;
      UpdateCatalogItemRequest.CatalogTypeId = catalogItem.CatalogTypeId;
      UpdateCatalogItemRequest.Description = catalogItem.Description;
      UpdateCatalogItemRequest.Name = catalogItem.Name;
      UpdateCatalogItemRequest.PictureUri = new Uri(catalogItem.PictureUri);
      UpdateCatalogItemRequest.Price = catalogItem.Price;
    }

    protected async Task HandleValidSubmit()
    {
      _ = await Mediator.Send(new EditCatalogItemAction { UpdateCatalogItemRequest = UpdateCatalogItemRequest });
      if (!string.IsNullOrEmpty(RedirectRoute))
      {
        _ = await Mediator.Send(new ChangeRouteAction { NewRoute = RedirectRoute });
      }
    }
  }
}

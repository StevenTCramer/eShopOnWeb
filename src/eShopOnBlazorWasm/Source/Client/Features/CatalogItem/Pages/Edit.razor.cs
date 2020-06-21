namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using eShopOnBlazorWasm.Features.Bases;
  using eShopOnBlazorWasm.Features.CatalogBrands;
  using eShopOnBlazorWasm.Features.CatalogItems;
  using eShopOnBlazorWasm.Features.CatalogTypes;
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public partial class Edit : BaseComponent
  {
    public const string RouteTemplate = "/Catalog/Edit/{EntityId}";

    private IReadOnlyList<CatalogTypeDto> CatalogTypes => CatalogTypeState.CatalogTypesAsList;
    private IReadOnlyList<CatalogBrandDto> CatalogBrands => CatalogBrandState.CatalogBrandsAsList;
    
    [Parameter] public int EntityId { get; set; }

    public UpdateCatalogItemRequest UpdateCatalogItemRequest { get; set; }

    public static string RouteFactory(int aEntityId) =>
      RouteTemplate.Replace($"{{{nameof(EntityId)}}}", aEntityId.ToString(), System.StringComparison.OrdinalIgnoreCase);

    protected async Task CancelClick() =>
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Pages.Index.RouteTemplate });

    protected async Task HandleValidSubmit()
    {
      _ = await Mediator.Send(new EditCatalogItemAction { UpdateCatalogItemRequest = UpdateCatalogItemRequest });
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Pages.Index.RouteTemplate });
    }

    protected override Task OnInitializedAsync()
    {
      CatalogItemDto catalogItem = CatalogItemState.CatalogItems[EntityId];
      UpdateCatalogItemRequest = new UpdateCatalogItemRequest();

      MapToRequest(catalogItem);

      return base.OnInitializedAsync();
    }

    private void MapToRequest(CatalogItemDto catalogItem)
    {
      // TODO: consider Automapper here
      UpdateCatalogItemRequest.CatalogItemId = catalogItem.Id;
      UpdateCatalogItemRequest.CatalogBrandId = catalogItem.CatalogBrandId;
      UpdateCatalogItemRequest.CatalogTypeId = catalogItem.CatalogTypeId;
      UpdateCatalogItemRequest.Description = catalogItem.Description;
      UpdateCatalogItemRequest.Name = catalogItem.Name;
      UpdateCatalogItemRequest.PictureUri = catalogItem.PictureUri;
      UpdateCatalogItemRequest.Price = catalogItem.Price;
    }
  }
}

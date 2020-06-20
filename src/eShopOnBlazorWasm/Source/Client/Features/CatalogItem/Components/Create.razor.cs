﻿namespace eShopOnBlazorWasm.Features.CatalogItems.Components
{
  using eShopOnBlazorWasm.Features.Bases;
  using eShopOnBlazorWasm.Features.CatalogBrands;
  using eShopOnBlazorWasm.Features.CatalogTypes;
  using Microsoft.AspNetCore.Components;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public partial class Create : BaseComponent
  {
    private IReadOnlyList<CatalogBrandDto> CatalogBrands => CatalogBrandState.CatalogBrandsAsList;
    private IReadOnlyList<CatalogTypeDto> CatalogTypes => CatalogTypeState.CatalogTypesAsList;
    public CreateCatalogItemRequest CreateCatalogItemRequest { get; set; }

    protected async Task CancelClick() =>
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Pages.Catalog.Index.Route });

    protected async Task HandleValidSubmit()
    {
      _ = await Mediator.Send(new CreateCatalogItemAction { CreateCatalogItemRequest = CreateCatalogItemRequest });
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Pages.Catalog.Index.Route });
    }

    protected override Task OnInitializedAsync()
    {
      CreateCatalogItemRequest = new CreateCatalogItemRequest();

      return base.OnInitializedAsync();
    }
  }
}

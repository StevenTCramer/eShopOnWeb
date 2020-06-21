namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using eShopOnBlazorWasm.Features.Bases;
  using eShopOnBlazorWasm.Features.CatalogBrands;
  using eShopOnBlazorWasm.Features.CatalogTypes;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using static BlazorState.Features.Routing.RouteState;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public partial class Create : BaseComponent
  {
    public const string RouteTemplate = "/Catalog/Create";

    private IReadOnlyList<CatalogBrandDto> CatalogBrands => CatalogBrandState.CatalogBrandsAsList;
    private IReadOnlyList<CatalogTypeDto> CatalogTypes => CatalogTypeState.CatalogTypesAsList;
    public CreateCatalogItemRequest CreateCatalogItemRequest { get; set; }

    protected async Task CancelClick() =>
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Index.RouteTemplate });

    protected async Task HandleValidSubmit()
    {
      _ = await Mediator.Send(new CreateCatalogItemAction { CreateCatalogItemRequest = CreateCatalogItemRequest });
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Index.RouteTemplate });
    }

    protected override Task OnInitializedAsync()
    {
      CreateCatalogItemRequest = new CreateCatalogItemRequest();

      return base.OnInitializedAsync();
    }
  }
}

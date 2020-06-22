namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using BlazorState.Features.Routing;
  using eShopOnBlazorWasm.Features.Bases;
  using System.Threading.Tasks;

  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public partial class Index : BaseComponent
  {
    public const string RouteTemplate = "/Catalog";
    public static string GetRoute() => RouteTemplate;

    protected async Task CreateClick() =>
      _ = await Mediator.Send(new RouteState.ChangeRouteAction { NewRoute = Create.RouteTemplate });

    protected async Task HandlePageChange(int aPageIndex)
    {
      _ = await Mediator.Send(new ChangePageAction { PageIndex = aPageIndex });
      _ = await Mediator.Send(new FetchCatalogItemsAction());
    }

    protected override async Task OnInitializedAsync()
    {
      _ = await Mediator.Send(new FetchCatalogItemsAction());
      await base.OnInitializedAsync();
    }
  }
}

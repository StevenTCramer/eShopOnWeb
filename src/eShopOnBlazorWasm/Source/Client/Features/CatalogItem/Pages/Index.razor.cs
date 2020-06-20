namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using BlazorState.Features.Routing;
  using eShopOnBlazorWasm.Features.Bases;
  using System.Threading.Tasks;

  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public partial class Index : BaseComponent
  {
    public const string Route = "/Catalog";

    protected async Task CreateClick() =>
      _ = await Mediator.Send(new RouteState.ChangeRouteAction { NewRoute = Create.Route });

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

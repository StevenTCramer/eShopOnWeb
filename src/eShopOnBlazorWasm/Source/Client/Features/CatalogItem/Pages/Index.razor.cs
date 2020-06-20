namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using BlazorState.Features.Routing;
  using eShopOnBlazorWasm.Features.Bases;
  using System.Threading.Tasks;

  public partial class Index: BaseComponent
  {
    public const string Route = "/Catalog";

    protected async Task CreateClick() =>
      _ = await Mediator.Send(new RouteState.ChangeRouteAction { NewRoute = Create.Route });
  }
}

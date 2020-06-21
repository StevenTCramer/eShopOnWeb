namespace eShopOnBlazorWasm.Pages
{
  using BlazorState.Features.Routing;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;

  public partial class CounterPage: BaseComponent
  {
    public const string RouteTemplate = "/counter";
    public static string GetRoute() => RouteTemplate;
    protected async Task ButtonClick() =>
      _ = await Mediator.Send(new RouteState.ChangeRouteAction { NewRoute = "/" });
  }
}

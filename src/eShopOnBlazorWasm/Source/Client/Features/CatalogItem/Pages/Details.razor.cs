namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;
  using Microsoft.AspNetCore.Components;
  using static BlazorState.Features.Routing.RouteState;

  public partial class Details : BaseComponent
  {
    public const string Route = "/Catalog/Details/{EntityId}";

    public static string RouteFactory(int aEntityId) =>
      Route.Replace($"{{{nameof(EntityId)}}}", aEntityId.ToString(), System.StringComparison.OrdinalIgnoreCase);

    [Parameter] public int EntityId { get; set; }

    protected async Task BackClick() =>
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Index.Route });
  }
}

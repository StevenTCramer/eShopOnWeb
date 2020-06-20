namespace eShopOnBlazorWasm.Pages.Catalog
{
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;
  using Microsoft.AspNetCore.Components;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;
  using static BlazorState.Features.Routing.RouteState;

  public partial class Delete: BaseComponent
  {
    public const string Route = "/Catalog/Delete/{EntityId}";

    public static string RouteFactory(int aEntityId) =>
      Route.Replace($"{{{nameof(EntityId)}}}", aEntityId.ToString(), System.StringComparison.OrdinalIgnoreCase);

    [Parameter] public int EntityId { get; set; }

    protected async Task DeleteClick() =>
      _ = await Mediator.Send(new DeleteCatalogItemAction { CatalogItemId = EntityId });
    protected async Task CancelClick() =>
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Pages.Catalog.Index.Route });
  }
}

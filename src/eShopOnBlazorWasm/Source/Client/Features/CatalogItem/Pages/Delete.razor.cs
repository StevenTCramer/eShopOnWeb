namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;
  using Microsoft.AspNetCore.Components;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;
  using static BlazorState.Features.Routing.RouteState;
  using System;

  public partial class Delete: BaseComponent
  {
    public const string RouteTemplate = "/Catalog/Delete/{EntityId}";

    public static string RouteFactory(int aEntityId) =>
      RouteTemplate.Replace($"{{{nameof(EntityId)}}}", aEntityId.ToString(), System.StringComparison.OrdinalIgnoreCase);

    [Parameter] public int EntityId { get; set; }

    protected async Task DeleteClick()
    {
      Console.WriteLine("DeleteClicked");
      _ = await Mediator.Send(new DeleteCatalogItemAction { CatalogItemId = EntityId });
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Index.RouteTemplate });
    }

    protected async Task CancelClick() =>
      _ = await Mediator.Send(new ChangeRouteAction { NewRoute = Index.RouteTemplate });
  }
}

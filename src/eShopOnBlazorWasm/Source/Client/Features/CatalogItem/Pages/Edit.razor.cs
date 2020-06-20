namespace eShopOnBlazorWasm.Features.CatalogItems.Pages
{
  using eShopOnBlazorWasm.Features.Bases;
  using Microsoft.AspNetCore.Components;

  public partial class Edit : BaseComponent
  {
    public const string Route = "/Catalog/Edit/{EntityId}";

    [Parameter] public int EntityId { get; set; }

    public static string RouteFactory(int aEntityId) =>
          Route.Replace($"{{{nameof(EntityId)}}}", aEntityId.ToString(), System.StringComparison.OrdinalIgnoreCase);
  }
}

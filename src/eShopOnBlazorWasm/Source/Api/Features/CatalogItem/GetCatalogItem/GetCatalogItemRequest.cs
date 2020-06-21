namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using eShopOnBlazorWasm.Features.Bases;
  using MediatR;

  public class GetCatalogItemRequest : BaseApiRequest, IRequest<GetCatalogItemResponse>
  {
    public const string RouteTemplate = "api/catalog-items/{CatalogItemId}";

    /// <summary>
    /// The specific CatalogItemId to fetch
    /// </summary>
    /// <example>5</example>
    public int CatalogItemId { get; set; }

    internal override string GetRoute() =>
      $"{RouteTemplate}?{nameof(CorrelationId)}={CorrelationId}"
      .Replace
      (
        $"{{{nameof(CatalogItemId)}}}",
        CatalogItemId.ToString(),
        System.StringComparison.OrdinalIgnoreCase
      );
  }
}

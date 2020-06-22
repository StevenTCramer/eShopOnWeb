namespace eShopOnBlazorWasm.Features.CatalogBrands
{
  using eShopOnBlazorWasm.Features.Bases;
  using MediatR;

  public class GetCatalogBrandsRequest : BaseApiRequest, IRequest<GetCatalogBrandsResponse>
  {
    public const string RouteTemplate = "api/CatalogBrands";

    internal override string GetRoute() => $"{RouteTemplate}?{nameof(CorrelationId)}={CorrelationId}";
  }
}

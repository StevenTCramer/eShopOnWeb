namespace eShopOnBlazorWasm.Features.CatalogTypes
{
  using eShopOnBlazorWasm.Features.Bases;
  using MediatR;

  public class GetCatalogTypesRequest : BaseApiRequest, IRequest<GetCatalogTypesResponse>
  {
    public const string RouteTemplate = "api/CatalogTypes";

    internal override string GetRoute() => $"{RouteTemplate}?{nameof(CorrelationId)}={CorrelationId}";
  }
}

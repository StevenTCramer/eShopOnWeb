namespace eShopOnBlazorWasm.Features.CatalogTypes
{
  using eShopOnBlazorWasm.Features.Bases;
  using MediatR;

  public class GetCatalogTypesRequest : BaseApiRequest, IRequest<GetCatalogTypesResponse>
  {
    public const string Route = "api/CatalogTypes";

    internal override string GetRoute() => $"{Route}?{nameof(CorrelationId)}={CorrelationId}";
  }
}

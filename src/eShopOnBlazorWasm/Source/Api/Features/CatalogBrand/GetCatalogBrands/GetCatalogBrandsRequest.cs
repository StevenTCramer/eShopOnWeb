namespace eShopOnBlazorWasm.Features.CatalogBrands
{
  using eShopOnBlazorWasm.Features.Bases;
  using MediatR;

  public class GetCatalogBrandsRequest : BaseApiRequest, IRequest<GetCatalogBrandsResponse>
  {
    public const string Route = "api/CatalogBrands";

    internal override string GetRoute() => $"{Route}?{nameof(CorrelationId)}={CorrelationId}";
  }
}

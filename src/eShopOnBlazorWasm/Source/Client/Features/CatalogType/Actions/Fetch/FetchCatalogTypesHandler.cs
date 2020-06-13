namespace eShopOnBlazorWasm.Features.CatalogTypes
{
  using BlazorState;
  using MediatR;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Threading;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;
  using eShopOnBlazorWasm.Features.WeatherForecasts;
  using static eShopOnBlazorWasm.Features.CatalogTypes.CatalogTypeState;
  using eShopOnBlazorWasm.Features.Catalogs;

  internal partial class CatalogTypeState
  {
    public class FetchCatalogTypesHandler : BaseHandler<FetchCatalogTypesAction>
    {
      private readonly HttpClient HttpClient;

      public FetchCatalogTypesHandler(IStore aStore, HttpClient aHttpClient) : base(aStore)
      {
        HttpClient = aHttpClient;
      }

      public override async Task<Unit> Handle
      (
        FetchCatalogTypesAction aFetchCatalogTypesAction,
        CancellationToken aCancellationToken
      )
      {
        var getCatalogTypesRequest = new GetCatalogTypesRequest();
        GetCatalogTypesResponse getCatalogTypesResponse =
          await HttpClient.GetFromJsonAsync<GetCatalogTypesResponse>(getCatalogTypesRequest.RouteFactory);
        CatalogTypeState._CatalogTypes = getCatalogTypesResponse.CatalogTypes;
        return Unit.Value;
      }
    }
  }
}
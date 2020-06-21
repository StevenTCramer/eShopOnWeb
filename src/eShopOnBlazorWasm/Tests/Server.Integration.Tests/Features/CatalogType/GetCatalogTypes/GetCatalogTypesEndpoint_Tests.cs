namespace GetCatalogTypesEndpoint
{
  using FluentAssertions;
  using Microsoft.AspNetCore.Mvc.Testing;
  using System.Text.Json;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Server.Integration.Tests.Infrastructure;
  using eShopOnBlazorWasm.Server;
  using eShopOnBlazorWasm.Features.CatalogTypes;
  using System.Net.Http.Json;

  public class Returns : BaseTest
  {
    private readonly GetCatalogTypesRequest GetCatalogTypesRequest;

    public Returns
    (
      WebApplicationFactory<Startup> aWebApplicationFactory,
      JsonSerializerOptions aJsonSerializerOptions
    ) : base(aWebApplicationFactory, aJsonSerializerOptions)
    {
      GetCatalogTypesRequest = new GetCatalogTypesRequest { };
    }

    public async Task AllCatalogTypes()
    {
      GetCatalogTypesResponse getCatalogTypesResponse =
        await HttpClient.GetFromJsonAsync<GetCatalogTypesResponse>(GetCatalogTypesRequest.RouteFactory);

      ValidateGetCatalogTypesResponse(getCatalogTypesResponse);
    }

    private void ValidateGetCatalogTypesResponse(GetCatalogTypesResponse aGetCatalogTypesResponse) =>
      aGetCatalogTypesResponse.CorrelationId.Should().Be(GetCatalogTypesRequest.CorrelationId);
  }
}
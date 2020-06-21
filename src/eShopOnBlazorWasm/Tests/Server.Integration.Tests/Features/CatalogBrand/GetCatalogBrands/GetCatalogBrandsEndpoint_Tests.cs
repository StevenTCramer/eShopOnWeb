namespace GetCatalogBrandsEnpoint
{
  using FluentAssertions;
  using Microsoft.AspNetCore.Mvc.Testing;
  using System.Text.Json;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Server.Integration.Tests.Infrastructure;
  using eShopOnBlazorWasm.Server;
  using eShopOnBlazorWasm.Features.CatalogBrands;
  using System.Net.Http.Json;

  public class Returns : BaseTest
  {
    private readonly GetCatalogBrandsRequest GetCatalogBrandsRequest;

    public Returns
    (
      WebApplicationFactory<Startup> aWebApplicationFactory,
      JsonSerializerOptions aJsonSerializerOptions
    ) : base(aWebApplicationFactory, aJsonSerializerOptions)
    {
      GetCatalogBrandsRequest = new GetCatalogBrandsRequest { };
    }

    public async Task AllCatalogBrands()
    {
      GetCatalogBrandsResponse getCatalogBrandsResponse =
      await HttpClient.GetFromJsonAsync<GetCatalogBrandsResponse>(GetCatalogBrandsRequest.GetRoute());

      ValidateGetCatalogBrandsResponse(getCatalogBrandsResponse);
    }

    private void ValidateGetCatalogBrandsResponse(GetCatalogBrandsResponse aGetCatalogBrandsResponse)
    {
      aGetCatalogBrandsResponse.CorrelationId.Should().Be(GetCatalogBrandsRequest.CorrelationId);
      //aGetCatalogBrandsResponse.CatalogBrands.Count.Should().Be(???);
    }
  }
}
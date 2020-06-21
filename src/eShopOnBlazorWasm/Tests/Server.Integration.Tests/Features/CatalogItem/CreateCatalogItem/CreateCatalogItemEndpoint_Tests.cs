namespace CreateCatalogItemEndpoint
{
  using eShopOnBlazorWasm.Features.CatalogItems;
  using eShopOnBlazorWasm.Server;
  using eShopOnBlazorWasm.Server.Integration.Tests.Infrastructure;
  using FluentAssertions;
  using Microsoft.AspNetCore.Mvc.Testing;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Text.Json;
  using System.Threading.Tasks;

  public class Returns : BaseTest
  {
    private readonly CreateCatalogItemRequest CreateCatalogItemRequest;

    public Returns
    (
      WebApplicationFactory<Startup> aWebApplicationFactory,
      JsonSerializerOptions aJsonSerializerOptions
    ) : base(aWebApplicationFactory, aJsonSerializerOptions)
    {
      CreateCatalogItemRequest = new CreateCatalogItemRequest
      {
        Name = "Test Valid Catalog Item",
        CatalogBrandId = 3,
        CatalogTypeId = 2,
        Description = "Test Valid Catalog Item Description",
        PictureUri = null,
        Price = 55.5M
      };
    }

    public async Task NewCatalogItem()
    {
      CreateCatalogItemResponse createCatalogItemResponse =
        await PostJsonAsync<CreateCatalogItemRequest, CreateCatalogItemResponse>
        (
          CreateCatalogItemRequest.RouteFactory,
          CreateCatalogItemRequest
        );

      ValidateCreateCatalogItemResponse(createCatalogItemResponse);
    }

    public async Task ValidationError()
    {
      // Set invalid value
      CreateCatalogItemRequest.Price = -1;

      HttpResponseMessage httpResponseMessage =
        await HttpClient.PostAsJsonAsync<CreateCatalogItemRequest>
        (
          CreateCatalogItemRequest.RouteFactory,
          CreateCatalogItemRequest
        );

      string json = await httpResponseMessage.Content.ReadAsStringAsync();

      httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
      json.Should().Contain("errors");
      json.Should().Contain(nameof(CreateCatalogItemRequest.Price));
    }

    private void ValidateCreateCatalogItemResponse(CreateCatalogItemResponse aCreateCatalogItemResponse)
    {
      aCreateCatalogItemResponse.CorrelationId.Should().Be(CreateCatalogItemRequest.CorrelationId);
    }
  }
}

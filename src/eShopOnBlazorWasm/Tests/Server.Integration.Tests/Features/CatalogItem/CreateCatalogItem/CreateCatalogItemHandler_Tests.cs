namespace CreateCatalogItemHandler
{
  using System.Threading.Tasks;
  using System.Text.Json;
  using Microsoft.AspNetCore.Mvc.Testing;
  using eShopOnBlazorWasm.Server.Integration.Tests.Infrastructure;
  using eShopOnBlazorWasm.Server;
  using FluentAssertions;
  using eShopOnBlazorWasm.Features.CatalogItems;

  public class Handle_Returns : BaseTest
  {
    private readonly CreateCatalogItemRequest CreateCatalogItemRequest;

    public Handle_Returns
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
      CreateCatalogItemResponse createCatalogItemResponse = await Send(CreateCatalogItemRequest);

      ValidateCreateCatalogItemResponse(createCatalogItemResponse);
    }

    private void ValidateCreateCatalogItemResponse(CreateCatalogItemResponse aCreateCatalogItemResponse)
    {
      aCreateCatalogItemResponse.CorrelationId.Should().Be(CreateCatalogItemRequest.CorrelationId);
    }

  }
}
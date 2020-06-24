namespace GetCatalogItemsPaginatedHandler
{
  using System.Threading.Tasks;
  using System.Text.Json;
  using Microsoft.AspNetCore.Mvc.Testing;
  using eShopOnBlazorWasm.Server.Integration.Tests.Infrastructure;
  using eShopOnBlazorWasm.Features.CatalogItems;
  using eShopOnBlazorWasm.Server;
  using FluentAssertions;

  public class Handle_Returns : BaseTest
  {
    private readonly GetCatalogItemsPaginatedRequest GetCatalogItemsPaginatedRequest;

    public Handle_Returns
    (
      WebApplicationFactory<Startup> aWebApplicationFactory,
      JsonSerializerOptions aJsonSerializerOptions
    ) : base(aWebApplicationFactory, aJsonSerializerOptions)
    {
      GetCatalogItemsPaginatedRequest = new GetCatalogItemsPaginatedRequest { PageIndex = 0, PageSize = 5 };
    }

    public async Task _5CatalogItems_Given_PageSize_5_Requested()
    {
      GetCatalogItemsPaginatedResponse getCatalogItemsPaginatedResponse = await Send(GetCatalogItemsPaginatedRequest);

      ValidateGetCatalogItemsPaginatedResponse(getCatalogItemsPaginatedResponse);
    }

    private void ValidateGetCatalogItemsPaginatedResponse(GetCatalogItemsPaginatedResponse aGetCatalogItemsPaginatedResponse)
    {
      aGetCatalogItemsPaginatedResponse.CorrelationId.Should().Be(GetCatalogItemsPaginatedRequest.CorrelationId);
      aGetCatalogItemsPaginatedResponse.CatalogItems.Count.Should().Be(GetCatalogItemsPaginatedRequest.PageSize);
      aGetCatalogItemsPaginatedResponse.PageCount.Should().Be(3); // 12 items seeded
    }

  }
}
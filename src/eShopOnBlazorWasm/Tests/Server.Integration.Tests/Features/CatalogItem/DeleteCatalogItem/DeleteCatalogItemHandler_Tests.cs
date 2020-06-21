﻿namespace DeleteCatalogItemHandler
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
    private readonly DeleteCatalogItemRequest DeleteCatalogItemRequest;

    public Handle_Returns
    (
      WebApplicationFactory<Startup> aWebApplicationFactory,
      JsonSerializerOptions aJsonSerializerOptions
    ) : base(aWebApplicationFactory, aJsonSerializerOptions)
    {
      DeleteCatalogItemRequest = new DeleteCatalogItemRequest { CatalogItemId = 8 };
    }

    public async Task DeleteCatalogItemResponse()
    {
      DeleteCatalogItemResponse deleteCatalogItemResponse = await Send(DeleteCatalogItemRequest);

      ValidateDeleteCatalogItemResponse(deleteCatalogItemResponse);
    }

    private void ValidateDeleteCatalogItemResponse(DeleteCatalogItemResponse aDeleteCatalogItemResponse)
    {
      aDeleteCatalogItemResponse.CorrelationId.Should().Be(DeleteCatalogItemRequest.CorrelationId);
      // check Other properties here
    }

  }
}
namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using BlazorState;
  using MediatR;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Threading;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;
  using System;
  using System.Text.Json;

  internal partial class CatalogItemState
  {
    public class CreateCatalogItemHandler : BaseHandler<CreateCatalogItemAction>
    {
      private readonly HttpClient HttpClient;
      private readonly JsonSerializerOptions JsonSerializerOptions;

      public CreateCatalogItemHandler
      (
        IStore aStore, 
        HttpClient aHttpClient,
        JsonSerializerOptions aJsonSerializerOptions
      ) : base(aStore)
      {
        HttpClient = aHttpClient;
        JsonSerializerOptions = aJsonSerializerOptions;
      }


      public override async Task<Unit> Handle
      (
        CreateCatalogItemAction aCreateCatalogItemAction,
        CancellationToken aCancellationToken
      )
      {
        Console.WriteLine($"Name:{aCreateCatalogItemAction.CreateCatalogItemRequest.Name}");
        HttpResponseMessage httpResponseMessage =
          await HttpClient.PostAsJsonAsync<CreateCatalogItemRequest>
          (
            aCreateCatalogItemAction.CreateCatalogItemRequest.RouteFactory,
            aCreateCatalogItemAction.CreateCatalogItemRequest
          );

        httpResponseMessage.EnsureSuccessStatusCode();

        string json = await httpResponseMessage.Content.ReadAsStringAsync();

        Console.WriteLine("==============");
        Console.WriteLine(json);

        CreateCatalogItemResponse createCatalogItemResponse = 
          JsonSerializer.Deserialize<CreateCatalogItemResponse>(json, JsonSerializerOptions);

        int newCatalogItemId = createCatalogItemResponse.CatalogItem.Id;

        CatalogItemState._CatalogItems[newCatalogItemId] = createCatalogItemResponse.CatalogItem;
        
        return Unit.Value;
      }
    }
  }
}

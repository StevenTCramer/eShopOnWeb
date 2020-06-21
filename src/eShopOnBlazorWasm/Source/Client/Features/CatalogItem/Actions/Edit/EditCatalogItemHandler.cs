namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using BlazorState;
  using MediatR;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Threading;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;
  using System.Text.Json;

  internal partial class CatalogItemState
  {
    public class EditCatalogItemHandler : BaseHandler<EditCatalogItemAction>
    {
      private readonly HttpClient HttpClient;
      private readonly JsonSerializerOptions JsonSerializerOptions;

      public EditCatalogItemHandler
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
        EditCatalogItemAction aCreateCatalogItemAction,
        CancellationToken aCancellationToken
      )
      {
        HttpResponseMessage httpResponseMessage =
          await HttpClient.PutAsJsonAsync<UpdateCatalogItemRequest>
          (
            aCreateCatalogItemAction.UpdateCatalogItemRequest.GetRoute(),
            aCreateCatalogItemAction.UpdateCatalogItemRequest
          );

        httpResponseMessage.EnsureSuccessStatusCode();

        string json = await httpResponseMessage.Content.ReadAsStringAsync();

        UpdateCatalogItemResponse updateCatalogItemResponse = 
          JsonSerializer.Deserialize<UpdateCatalogItemResponse>(json, JsonSerializerOptions);

        int catalogItemId = updateCatalogItemResponse.CatalogItem.Id;

        CatalogItemState._CatalogItems[catalogItemId] = updateCatalogItemResponse.CatalogItem;
        
        return Unit.Value;
      }
    }
  }
}

namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using BlazorState;
  using MediatR;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Threading;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.Bases;

  internal partial class CatalogItemState
  {
    public class DeleteCatalogItemHandler : BaseHandler<DeleteCatalogItemAction>
    {
      private readonly HttpClient HttpClient;

      public DeleteCatalogItemHandler
      (
        IStore aStore, 
        HttpClient aHttpClient
      ) : base(aStore)
      {
        HttpClient = aHttpClient;
      }

      public override async Task<Unit> Handle
      (
        DeleteCatalogItemAction aDeleteCatalogItemAction,
        CancellationToken aCancellationToken
      )
      {
        var deleteCatalogItemRequest = new DeleteCatalogItemRequest
        {
          CatalogItemId = aDeleteCatalogItemAction.CatalogItemId
        };

        HttpResponseMessage httpResponseMessage =
          await HttpClient.DeleteAsync(deleteCatalogItemRequest.GetRoute());

        httpResponseMessage.EnsureSuccessStatusCode();

        CatalogItemState._CatalogItems.Remove(aDeleteCatalogItemAction.CatalogItemId);
        
        return Unit.Value;
      }
    }
  }
}

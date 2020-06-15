namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using eShopOnBlazorWasm.Features.Bases;

  internal partial class CatalogItemState
  {
    public class CreateCatalogItemAction : BaseAction 
    {
      public CreateCatalogItemRequest CreateCatalogItemRequest { get; set; }
    }
  }
}

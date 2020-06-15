namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using eShopOnBlazorWasm.Features.Bases;

  internal partial class CatalogItemState
  {
    public class EditCatalogItemAction : BaseAction 
    {
      public UpdateCatalogItemRequest UpdateCatalogItemRequest { get; set; }
    }
  }
}

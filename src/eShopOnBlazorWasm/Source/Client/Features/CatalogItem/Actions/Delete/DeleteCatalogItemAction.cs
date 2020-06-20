namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using eShopOnBlazorWasm.Features.Bases;

  internal partial class CatalogItemState
  {
    public class DeleteCatalogItemAction : BaseAction 
    {
      public int CatalogItemId { get; set; }
    }
  }
}

namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using eShopOnBlazorWasm.Features.Bases;

  internal partial class CatalogItemState
  {
    public class ChangePageAction : BaseAction 
    {
      public int  PageIndex { get; set; }
    }
  }
}

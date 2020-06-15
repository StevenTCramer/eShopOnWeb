namespace eShopOnBlazorWasm.Features.CatalogItems.Components
{
  using Microsoft.AspNetCore.Components;
  public partial class Details
  {
    public CatalogItemDto CatalogItem => 
      CatalogItemState.CatalogItems[CatalogItemId];

    [Parameter] public int CatalogItemId { get; set; }

    public string CatalogBrand => CatalogBrandState.CatalogBrands[CatalogItem.CatalogBrandId].Brand;
    public string CatalogType => CatalogTypeState.CatalogTypes[CatalogItem.CatalogTypeId].Type;
  }
}

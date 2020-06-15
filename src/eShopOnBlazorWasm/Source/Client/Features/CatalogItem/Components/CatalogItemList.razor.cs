namespace eShopOnBlazorWasm.Features.CatalogItems.Components
{
  using System.Threading.Tasks;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public partial class CatalogItemList
  {
    protected async Task HandlePageChange(int aPageIndex) =>
      _ = await Mediator.Send(new ChangePageAction { PageIndex = aPageIndex });
  }
}

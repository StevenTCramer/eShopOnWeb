namespace eShopOnBlazorWasm.Components
{
  using eShopOnBlazorWasm.Features.Bases;
  using Microsoft.AspNetCore.Components;
  using System.Threading.Tasks;

  public partial class Pager:BaseComponent
  {
    [Parameter] public EventCallback<int> OnPageChange { get; set; }
    [Parameter] public int PageCount { get; set; }
    [Parameter] public int PageIndex { get; set; }

    private async Task OnClick(int aPageIndex)
    {
      await OnPageChange.InvokeAsync(aPageIndex);
    }
  }
}

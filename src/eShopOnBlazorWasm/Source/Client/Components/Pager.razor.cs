namespace eShopOnBlazorWasm.Components
{
  using eShopOnBlazorWasm.Features.Bases;
  using Microsoft.AspNetCore.Components;
  using System.Threading.Tasks;

  public partial class Pager : BaseComponent
  {
    [Parameter] public EventCallback<int> OnPageChange { get; set; }
    [Parameter] public int PageCount { get; set; }
    [Parameter] public int PageIndex { get; set; }

    protected bool IsNextDisabled => PageIndex == PageCount - 1;
    protected bool IsPreviousDisabled => PageIndex == 0;

    protected async Task OnNextClick() => await OnPageChange.InvokeAsync(PageIndex + 1);

    protected async Task OnPreviousClick() => await OnPageChange.InvokeAsync(PageIndex - 1);
  }
}

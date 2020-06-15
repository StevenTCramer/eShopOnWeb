namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using BlazorState;
  using eShopOnBlazorWasm.Features.Bases;
  using MediatR;
  using System.Threading;
  using System.Threading.Tasks;
  internal partial class CatalogItemState
  {
    public class ChangePageHandler : BaseHandler<ChangePageAction>
    {
      public ChangePageHandler(IStore aStore) : base(aStore) { }
      
      public override Task<Unit> Handle(ChangePageAction aChangePageAction, CancellationToken aCancellationToken)
      {
        CatalogItemState.PageIndex = aChangePageAction.PageIndex;
        return Unit.Task;
      }
    }
  }
}

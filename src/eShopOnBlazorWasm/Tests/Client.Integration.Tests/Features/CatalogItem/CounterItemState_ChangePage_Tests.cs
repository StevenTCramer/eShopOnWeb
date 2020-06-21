namespace CatalogItemState
{
  using Shouldly;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.CatalogItems;
  using eShopOnBlazorWasm.Client.Integration.Tests.Infrastructure;
  using static eShopOnBlazorWasm.Features.CatalogItems.CatalogItemState;

  public class ChangePageAction_Should : BaseTest
  {
    private CatalogItemState CatalogItemState => Store.GetState<CatalogItemState>();

    public ChangePageAction_Should(ClientHost aWebAssemblyHost) : base(aWebAssemblyHost) { }

    public async Task Assign_A_Given_Page_Index()
    {
      //Arrange 
      CatalogItemState.Initialize();

      var changePageRequest = new ChangePageAction
      {
        PageIndex = 42
      };

      //Act
      await Send(changePageRequest);

      //Assert
      CatalogItemState.PageIndex.ShouldBe(changePageRequest.PageIndex);
    }
  }
}

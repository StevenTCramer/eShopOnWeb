namespace eShopOnBlazorWasm.Components
{
  using BlazorState.Features.JavaScriptInterop;
  using BlazorState.Features.Routing;
  using BlazorState.Pipeline.ReduxDevTools;
  using Microsoft.AspNetCore.Components;
  using System.Threading.Tasks;
  using eShopOnBlazorWasm.Features.ClientLoaders;
  using eShopOnBlazorWasm.Features.Bases;
  using static eShopOnBlazorWasm.Features.CatalogTypes.CatalogTypeState;
  using static eShopOnBlazorWasm.Features.CatalogBrands.CatalogBrandState;

  public partial class App : BaseComponent
  {
    [Inject] private ClientLoader ClientLoader { get; set; }
    [Inject] private JsonRequestHandler JsonRequestHandler { get; set; }
#if ReduxDevToolsEnabled
    [Inject] private ReduxDevToolsInterop ReduxDevToolsInterop { get; set; }
#endif
    [Inject] private RouteManager RouteManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await Mediator.Send(new FetchCatalogTypesAction());
      await Mediator.Send(new FetchCatalogBrandsAction());

      await base.OnInitializedAsync();
    }
    protected override async Task OnAfterRenderAsync(bool aFirstRender)
    {
#if ReduxDevToolsEnabled
      await ReduxDevToolsInterop.InitAsync();
#endif
      await JsonRequestHandler.InitAsync();
      await ClientLoader.InitAsync();
    }
  }
}

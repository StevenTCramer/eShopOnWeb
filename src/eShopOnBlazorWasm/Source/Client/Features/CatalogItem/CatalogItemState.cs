namespace eShopOnBlazorWasm.Features.CatalogItems
{
  using BlazorState;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text.Json.Serialization;

  internal partial class CatalogItemState : State<CatalogItemState>
  {
    public int PageSize { get; private set; }
    public int PageIndex { get; private set; }
    public int PageCount { get; private set; }

    private Dictionary<int, CatalogItemDto> _CatalogItems;

    [JsonIgnore]
    public IReadOnlyDictionary<int, CatalogItemDto> CatalogItems => _CatalogItems;

    public IReadOnlyList<CatalogItemDto> CatalogItemsAsList => _CatalogItems.Values.ToList();

    public CatalogItemState() { }

    /// <summary>
    /// Set the Initial State
    /// </summary>
    public override void Initialize()
    {
      Console.WriteLine("Initialize CatalogItemState");
      PageCount = 0;
      PageIndex = 0;
      PageSize = 5;
      _CatalogItems = new Dictionary<int, CatalogItemDto>();
    }
  }
}

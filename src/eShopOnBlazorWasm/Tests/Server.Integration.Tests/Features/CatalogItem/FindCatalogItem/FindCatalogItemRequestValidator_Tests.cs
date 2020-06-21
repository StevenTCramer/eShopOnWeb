namespace FindCatalogItemRequestValidator_
{
  using FluentAssertions;
  using FluentValidation.Results;
  using FluentValidation.TestHelper;
  using eShopOnBlazorWasm.Features.CatalogItems;

  public class Validate_Should
  {
    private FindCatalogItemRequestValidator FindCatalogItemRequestValidator { get; set; }
    private FindCatalogItemRequest FindCatalogItemRequest { get; set; }

    public Validate_Should()
    {
      new FindCatalogItemRequestValidator();
      FindCatalogItemRequest = new FindCatalogItemRequest
      {
        // Set Valid values here
        CatalogBrandId = 2,
        CatalogTypeId = 3
      };
    }

    public void Be_Valid()
    {
      ValidationResult validationResult = FindCatalogItemRequestValidator.TestValidate(FindCatalogItemRequest);

      validationResult.IsValid.Should().BeTrue();
    }

    public void Have_error_when_Days_are_negative() => FindCatalogItemRequestValidator
      .ShouldHaveValidationErrorFor(aFindCatalogItemRequest => aFindCatalogItemRequest.CatalogBrandId, -1);
  }
}

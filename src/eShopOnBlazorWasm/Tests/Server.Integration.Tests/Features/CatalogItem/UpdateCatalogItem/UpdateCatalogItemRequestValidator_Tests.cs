namespace UpdateCatalogItemRequestValidator_
{
  using FluentAssertions;
  using FluentValidation.Results;
  using FluentValidation.TestHelper;
  using eShopOnBlazorWasm.Features.CatalogItems;

  public class Validate_Should
  {
    private UpdateCatalogItemRequestValidator UpdateCatalogItemRequestValidator { get; set; }
    private UpdateCatalogItemRequest UpdateCatalogItemRequest { get; set; }

    public Validate_Should()
    {
      UpdateCatalogItemRequestValidator = new UpdateCatalogItemRequestValidator();
      UpdateCatalogItemRequest = new UpdateCatalogItemRequest
      {
        // Set Valid values here
        CatalogItemId = 6,
        Name = "Updated Name",
        Description = "Update me",
        Price = 15.00M,
        CatalogBrandId = 5,
        CatalogTypeId = 2,
        PictureUri = "/images/products/8.png",
      };
    }

    public void Be_Valid()
    {
      ValidationResult validationResult = UpdateCatalogItemRequestValidator.TestValidate(UpdateCatalogItemRequest);

      validationResult.IsValid.Should().BeTrue();
    }

    public void Have_error_when_Days_are_negative() => UpdateCatalogItemRequestValidator
      .ShouldHaveValidationErrorFor(aUpdateCatalogItemRequest => aUpdateCatalogItemRequest.Price, -1);
  }
}

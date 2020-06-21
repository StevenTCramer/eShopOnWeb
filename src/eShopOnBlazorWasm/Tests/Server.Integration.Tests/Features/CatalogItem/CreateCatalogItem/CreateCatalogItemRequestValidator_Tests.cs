namespace CreateCatalogItemRequestValidator_
{
  using FluentAssertions;
  using FluentValidation.Results;
  using FluentValidation.TestHelper;
  using eShopOnBlazorWasm.Features.CatalogItems;

  public class Validate_Should
  {
    private readonly CreateCatalogItemRequest CreateCatalogItemRequest;

    private CreateCatalogItemRequestValidator CreateCatalogItemRequestValidator { get; set; }

    public Validate_Should()
    {
      CreateCatalogItemRequest = new CreateCatalogItemRequest
      {
        Name = "Test Valid Catalog Item",
        CatalogBrandId = 3,
        CatalogTypeId = 2,
        Description = "Test Valid Catalog Item Description",
        PictureUri = null,
        Price = 55.5M
      };
    }

    public void Be_Valid()
    {
      ValidationResult validationResult = 
        CreateCatalogItemRequestValidator.TestValidate(CreateCatalogItemRequest);

      validationResult.IsValid.Should().BeTrue();
    }

    public void Have_error_when_Price_is_negative() => CreateCatalogItemRequestValidator
      .ShouldHaveValidationErrorFor(aCreateCatalogItemRequest => aCreateCatalogItemRequest.Price, -1);

    public void Setup() => CreateCatalogItemRequestValidator = new CreateCatalogItemRequestValidator();
  }
}

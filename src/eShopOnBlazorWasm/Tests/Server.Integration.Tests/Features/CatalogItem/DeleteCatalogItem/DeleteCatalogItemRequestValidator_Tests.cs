namespace DeleteCatalogItemRequestValidator_
{
  using FluentAssertions;
  using FluentValidation.Results;
  using FluentValidation.TestHelper;
  using eShopOnBlazorWasm.Features.CatalogItems;

  public class Validate_Should
  {
    private DeleteCatalogItemRequestValidator DeleteCatalogItemRequestValidator { get; set; }

    private DeleteCatalogItemRequest DeleteCatalogItemRequest { get; set; }

    public Validate_Should()
    {
      DeleteCatalogItemRequest = new DeleteCatalogItemRequest
      {
        CatalogItemId = 5
      };
    }

    public void Be_Valid()
    {
      ValidationResult validationResult = DeleteCatalogItemRequestValidator.TestValidate(DeleteCatalogItemRequest);

      validationResult.IsValid.Should().BeTrue();
    }

    public void Have_error_when_CatalogItemId_is_negative() => DeleteCatalogItemRequestValidator
      .ShouldHaveValidationErrorFor(aDeleteCatalogItemRequest => aDeleteCatalogItemRequest.CatalogItemId, -1);

    public void Setup() => DeleteCatalogItemRequestValidator = new DeleteCatalogItemRequestValidator();
  }
}

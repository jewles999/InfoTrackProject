using FluentValidation.TestHelper;
using InfoTrack.Application.CustomErrorMessages;
using InfoTrack.Application.Validators;
using InfoTrack.Domain.InputModels;

namespace InfoTrack.UnitTests
{
    public class InputValidatorTests
    {
        private readonly InputValidator _validator;
        public InputValidatorTests()
        {
            _validator = new InputValidator();
        }
        [Fact]
        public void Should_Produce_Error_Search_Term_Contains_Special_Characters()
        {
            var model = new SearchInput { SearchTerm = "$$$", DomainName = "abc.com" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.SearchTerm)
                .WithErrorMessage(InputValidationMessages.SearchTermErrorMessage);
        }

        [Fact]
        public void Should_Produce_Error_Domain_Name_Invalid()
        {
            var model = new SearchInput { SearchTerm = "aaa", DomainName = "abccom" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.DomainName)
                .WithErrorMessage(InputValidationMessages.DomainFormatErrorMessage);
        }

        [Theory]
        [InlineData("aaa", "123abc.com")]
        [InlineData("efiling integration", "www.infotrack.com")]
        [InlineData("another search 123", "google.gov")]
        public void Should_Validate_Valid_Input(string searchTerm, string domainName)
        {
            var model = new SearchInput { SearchTerm = searchTerm, DomainName = domainName };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
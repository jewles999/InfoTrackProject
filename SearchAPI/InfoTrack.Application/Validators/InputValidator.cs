using FluentValidation;
using InfoTrack.Application.CustomErrorMessages;
using InfoTrack.Domain.InputModels;
using System.Text.RegularExpressions;

namespace InfoTrack.Application.Validators
{
    public class InputValidator : AbstractValidator<SearchInput>
    {
        public InputValidator()
        {
            RuleFor(x => x.SearchTerm)
                .NotEmpty()
                .Must(y => IsLetterOrDigitWithSpace(y))
                .WithMessage(InputValidationMessages.SearchTermErrorMessage);
            RuleFor(x => x.DomainName)
                .NotEmpty()
                .Must(y => IsValidDomainPattern(y))
                .WithMessage(InputValidationMessages.DomainFormatErrorMessage);
        }

        private static bool IsLetterOrDigitWithSpace(string input)
        {
            return input.All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c));
        }

        private static bool IsValidDomainPattern(string input)
        {
            var pattern = @"^[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,7}$";
            Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            return m.Success;
        }
    }
}

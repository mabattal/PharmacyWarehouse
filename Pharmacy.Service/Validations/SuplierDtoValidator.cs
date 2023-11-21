using FluentValidation;
using Pharmacy.Core.DTOs;

namespace Pharmacy.Service.Validations
{
    public class SuplierDtoValidator : AbstractValidator<SuplierDto>
    {
        public SuplierDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.TaxNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeNumeric).WithMessage("Enter numbers only.")
                .Length(10).WithMessage("{PropertyName} length must be equal to 10.");
        }

        private bool BeNumeric(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (long.TryParse(value.Trim(), out _))
            {
                return true;
            }

            return false;
        }
    }
}

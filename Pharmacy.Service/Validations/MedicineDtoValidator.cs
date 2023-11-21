using FluentValidation;
using Pharmacy.Core.DTOs;

namespace Pharmacy.Service.Validations
{
    public class MedicineDtoValidator : AbstractValidator<MedicineDto>
    {
        public MedicineDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");

            RuleFor(x => x.Price)
                .InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");

            RuleFor(x => x.SuplierId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeNumeric).WithMessage("Enter numbers only.")
                .Length(13).WithMessage("{PropertyName} length is must equal 13.");

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

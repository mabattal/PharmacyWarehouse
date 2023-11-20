using FluentValidation;
using Pharmacy.Core.DTOs;

namespace Pharmacy.Service.Validations
{
    public class MedicineDtoValidator : AbstractValidator<MedicineDto>
    {
        public MedicineDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is requared.").NotEmpty().WithMessage("{PropertyName} is requared.");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");
            RuleFor(x => x.SuplierId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0.");
            RuleFor(x => x.Barcode).Length(13).WithMessage("{PropertyName} length is must equal 13.").NotNull().WithMessage("{PropertyName} is requared.").NotEmpty().WithMessage("{PropertyName} is requared.");
        }
    }
}

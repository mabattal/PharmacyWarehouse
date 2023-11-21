using FluentValidation;
using Pharmacy.Core.DTOs;

namespace Pharmacy.Service.Validations
{
    public class SuplierDtoValidator : AbstractValidator<SuplierDto>
    {
        public SuplierDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is requared.").NotEmpty().WithMessage("{PropertyName} is requared.");
            RuleFor(x => x.TaxNumber).NotNull().WithMessage("{PropertyName} is requared.").NotEmpty().WithMessage("{PropertyName} is requared.").Length(10).WithMessage("{PropertyName} length is must equal 10.");
        }
    }
}

using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class CountryBorderDtoValidator : AbstractValidator<CountryBorderDto>
    {
        public CountryBorderDtoValidator()
        {

            RuleFor(x => x.Names).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

            
        }


    }
}

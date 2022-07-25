using CarsAndDrivers.UseCases.Cars;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Brands.AddBrand
{
    public class AddBrandValidator : AbstractValidator<AddBrandCommand>
    {
        public AddBrandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(br => br.BrandName)
                .NotEmpty()
                .WithMessage("Field cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())
              
                .MinimumLength(2)
                .WithMessage("Brand name is too Short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())
                
                .MaximumLength(50)
                .WithMessage("Brand name is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
        }

       
    }
}
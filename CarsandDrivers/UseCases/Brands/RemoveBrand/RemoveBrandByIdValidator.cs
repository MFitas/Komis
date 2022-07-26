using System.Linq;
using CarsAndDrivers.Infrastructure;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Brands.RemoveBrand
{
    public class RemoveBrandByIdValidator : BrandValidator<RemoveBrandByIdCommand>
    {
        public RemoveBrandByIdValidator(CarsDriversContext context) : base(context)
        {
            
            RuleFor(gt => gt.Id)
                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())
           
                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithMessage(ErrorCode.NotFound.ToString());
        }
    }
}
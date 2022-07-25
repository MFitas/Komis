using System.Linq;
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
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString());
        }
        public bool BeValidId(int id) =>
            _carsDriversContext.Cars.FirstOrDefault(x => x.CarId == id) != null;
    }
}
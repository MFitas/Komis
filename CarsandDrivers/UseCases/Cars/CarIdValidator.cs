using System;
using System.Linq;
using CarsAndDrivers.UseCases.Cars.GetCarById;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Cars
{
    public class CarIdValidator : CarValidator<GetCarByIdQuery>
    {
        protected CarIdValidator(CarsDriversContext context) : base(context)
        {
            RuleFor(gt => gt.id)
                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString());
        }
        protected bool BeValidId(int id) =>
            _carsDriversContext.Cars.FirstOrDefault(x => x.CarId == id) != null;
        

       

    }
}
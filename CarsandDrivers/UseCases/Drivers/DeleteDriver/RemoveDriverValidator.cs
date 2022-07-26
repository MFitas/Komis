using System.Linq;
using CarsAndDrivers.Infrastructure;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Drivers.DeleteDriver
{
    public class RemoveDriveValidator : DriverValidator<RemoveDriverCommand>
    {
        public RemoveDriveValidator(CarsDriversContext context) : base(context)
        {
            RuleFor(dr => dr.Id)
                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithErrorCode(ErrorCode.NotFound.ToString());
        }

        private bool BeValidId( int id) =>
            _carsDriversContext.Drivers.FirstOrDefault(dr => dr.DriverId == id) != null;
        
    }
    
        
    
}
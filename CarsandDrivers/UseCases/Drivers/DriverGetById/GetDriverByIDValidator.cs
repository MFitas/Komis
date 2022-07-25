using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Drivers.DriverGetById
{
    public class GetDriverByIDValidator : DriverValidator<GetDriverQuery>
    {
        public GetDriverByIDValidator(CarsDriversContext context) : base(context)
        {
            RuleFor(dr => dr.Id)
                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())
                
                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithErrorCode(ErrorCode.NotFound.ToString());
        }

        private bool BeValidId(int id) => 
            _carsDriversContext.Drivers.FirstOrDefault(dr => dr.DriverId == id) != null;
        
    }
}
using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Drivers.UpdateDriverById
{
    public class UpdateDriverValidator : DriverValidator<UpdateDriverCommand>
    {
        public UpdateDriverValidator(CarsDriversContext context) : base(context)
        {
            RuleFor(dr => dr.Id)
                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithErrorCode(ErrorCode.NotFound.ToString());
            
            RuleFor(dr => dr.FirstName)
                .NotEmpty()
                .WithMessage("Name cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())
                
                .MinimumLength(3)
                .WithMessage("Name is too short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())
                
                .MaximumLength(50)
                .WithMessage("Name is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
            
            RuleFor((sn=>sn.SecondName))
                .NotEmpty()
                .WithMessage("Second Name Cant be Empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                .MinimumLength(3)
                .WithMessage("Second Name is too short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())

                .MaximumLength(50)
                .WithMessage("Second Name is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
            
            
            RuleFor(oc=>oc.Occupation)
                .NotEmpty()
                .WithMessage("Occupation Cant be Empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                .MinimumLength(3)
                .WithMessage("Occupation is too short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())

                .MaximumLength(50)
                .WithMessage("Occupation is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
        }

        private bool BeValidId(int id) => 
            _carsDriversContext.Drivers.FirstOrDefault(dr => dr.DriverId == id) != null;
    }
}
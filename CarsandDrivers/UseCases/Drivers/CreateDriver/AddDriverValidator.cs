using FluentValidation;

namespace CarsAndDrivers.UseCases.Drivers.CreateDriver
{
    public class AddDriverValidator : AbstractValidator<AddDriverCommand>
    {
        public AddDriverValidator()
        {
            RuleFor(fn => fn.FirstName)
                .NotEmpty()
                .WithMessage("Name Cant be Empty")
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
    }
}
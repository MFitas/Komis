using CarsAndDrivers.Infrastructure;
using FluentValidation;
using Npgsql.Replication.PgOutput.Messages;

namespace CarsAndDrivers.UseCases.Cars.DeleteCar
{
    public class RemoveCarByIdValidator : CarIdValidator
    {

        public RemoveCarByIdValidator(CarsDriversContext context) : base(context)
        {

            RuleFor(rm => rm.Id)
                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithErrorCode(ErrorCode.NotFound.ToString());


        }
        
    }
}
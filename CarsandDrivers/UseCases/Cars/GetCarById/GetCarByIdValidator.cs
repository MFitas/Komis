using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace CarsAndDrivers.UseCases.Cars.GetCarById
{
    public class GetCarByIdValidator : CarIdValidator
    {
        
        public GetCarByIdValidator(CarsDriversContext context) : base(context)
        {
            
            RuleFor(gt => gt.id)
                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithErrorCode(ErrorCode.NotFound.ToString());


        }

       
    }
}
using System.Linq;
using CarsAndDrivers.UseCases.Cars;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Models.CreateModel
{
    public class AddModelValidator : ModelsValidator<AddModelCommand>
    {
        public AddModelValidator(CarsDriversContext carsDriversContext) : base(carsDriversContext)
        {
            RuleFor(md => md.ModelName)
                .Must(beuniqe)
                .WithMessage("That model already exists")
                .WithErrorCode(ErrorCode.InvalidModel.ToString());
            
                
        }

        private bool beuniqe(string modelName, string brand)
        {
            
            var model = _carsDriversContext.CarModels.Select(md => new CarModel()
            {
                ModelName = md.ModelName
                
            }).ToListAsync();

            if (model)
            {
                
            }
            return 

        }
    }
}
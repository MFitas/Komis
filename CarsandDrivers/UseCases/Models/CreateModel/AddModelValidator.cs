using System.Linq;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.UseCases.Cars;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Models.CreateModel
{
    public class AddModelValidator : ModelsValidator<AddModelCommand>
    {
        public AddModelValidator(CarsDriversContext carsDriversContext) : base(carsDriversContext)
        {
            RuleFor(md => md.BrandName)
                .Must(BeValidBrand)
                .WithMessage("Brand does not exist")
                .WithErrorCode(ErrorCode.InvalidBrand.ToString());
                
            RuleFor(md => md.ModelName)
                .Must(beuniqe)
                .WithMessage("That model already exists")
                .WithErrorCode(ErrorCode.InvalidModel.ToString());
            
                
        }

        protected bool BeValidBrand(string brand)
        {
            return  _carsDriversContext.CarBrands
                .Include(x=> x.Models)
                .FirstOrDefault(x=>x.BrandName== brand) is not null;
        }
        private bool beuniqe(AddModelCommand command, string modelName)
        {

            var uniqueBrand = _carsDriversContext.CarBrands.Local
                .First(x=>x.BrandName== command.BrandName);

            return !uniqueBrand.Models.Any(x => x.ModelName == command.ModelName);

        }
    }
}
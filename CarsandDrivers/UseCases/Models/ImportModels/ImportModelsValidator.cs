using System.Linq;
using CarsAndDrivers.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Models.ImportModels
{
    public class ImportModelsValidator : ModelsValidator<ImportModelsCommand>
    {
        public ImportModelsValidator(CarsDriversContext carsDriversContext) : base(carsDriversContext)
        {
            RuleFor(md => md.BrandId)
                .Must(BeValidBrand)
                .WithMessage("Brand does not exist")
                .WithErrorCode(ErrorCode.InvalidBrand.ToString());
        }
        protected bool BeValidBrand(int brandId)
        {
            return  _carsDriversContext.CarBrands
                .Include(x=> x.Models)
                .FirstOrDefault(x=>x.BrandId == brandId) is not null;
            
        }
    }
}
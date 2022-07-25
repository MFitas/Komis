using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Brands
{
    public class BrandValidator<TModel> : AbstractValidator<TModel>
    {
        private protected readonly CarsDriversContext _carsDriversContext;

        public BrandValidator(CarsDriversContext context)
        {
            _carsDriversContext = context;
            
            
        }
        
        
        public bool BeValidId(int id) =>
            _carsDriversContext.CarBrands.FirstOrDefault(x => x.BrandId == id) != null;
        
    }
}
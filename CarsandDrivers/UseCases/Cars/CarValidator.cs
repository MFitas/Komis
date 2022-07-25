using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Cars
{
    public class CarValidator<TModel> : AbstractValidator<TModel>
    {
        private protected readonly CarsDriversContext _carsDriversContext;

        public CarValidator(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
    }
}
using System.Linq;
using CarsAndDrivers.Infrastructure;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Cars
{
    public class CarValidator<TModel> : AbstractValidator<TModel>
    {
        protected readonly CarsDriversContext _carsDriversContext;

        public CarValidator(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
    }
}
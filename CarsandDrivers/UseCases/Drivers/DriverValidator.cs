using CarsAndDrivers.Infrastructure;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Drivers
{
    public class DriverValidator<TModel> : AbstractValidator<TModel>
    {
        private protected readonly CarsDriversContext _carsDriversContext;

        public DriverValidator(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
    }
}
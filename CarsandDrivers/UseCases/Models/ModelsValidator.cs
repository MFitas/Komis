using CarsAndDrivers.UseCases.Models.CreateModel;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Models
{
    public class ModelsValidator<TModel> : AbstractValidator<TModel>
    {
        private protected readonly CarsDriversContext _carsDriversContext;

        public ModelsValidator(CarsDriversContext carsDriversContext)
        {
            _carsDriversContext = carsDriversContext;
        }
    }
}
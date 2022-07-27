using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.Infrastructure.Entities;
using CarsAndDrivers.UseCases.Cars;
using MediatR;

namespace CarsAndDrivers.UseCases.Brands.AddBrand
{
    public class AddBrandHandler : IRequestHandler<AddBrandCommand, Unit>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public AddBrandHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }


        public async Task<Unit> Handle(AddBrandCommand command, CancellationToken cancellationToken)
        {
            List<CarBrand> brandlist = new List<CarBrand>();
            
            var newBrand = new CarBrand
            {
                BrandName = command.BrandName
            };
            
            brandlist.Add(newBrand);

            await _carsDriversContext.AddRangeAsync(brandlist, cancellationToken);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
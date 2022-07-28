using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.Infrastructure.Entities;
using CarsAndDrivers.UseCases.Brands.BrandsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Brands.AddManyBrands
{
    public class AddManyBrandsHandler : IRequestHandler<AddManyBrandsCommand>
    {
        
        private readonly CarsDriversContext _carsDriversContext;

        public AddManyBrandsHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
        public async Task<Unit> Handle(AddManyBrandsCommand command, CancellationToken cancellationToken)
        {
            List<CarBrand> brandlist = new List<CarBrand>();

            var carBrands = command.BrandNames.Select(brandName => new CarBrand { BrandName = brandName.BrandName })
                .ToList();


            await _carsDriversContext.AddRangeAsync(carBrands, cancellationToken);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
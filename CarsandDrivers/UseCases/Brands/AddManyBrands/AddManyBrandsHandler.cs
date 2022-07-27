using System.Collections.Generic;
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

            var carBrands = new List<CarBrand>();
            
            foreach (var brandName  in command.BrandNames)
            {
               carBrands.Add(new CarBrand
               {
                   BrandName = brandName.BrandName
               });
            }
           
            
            

            await _carsDriversContext.AddRangeAsync(carBrands, cancellationToken);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
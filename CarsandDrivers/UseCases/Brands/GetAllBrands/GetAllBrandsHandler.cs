using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Brands.BrandsModels;
using CarsAndDrivers.UseCases.Cars.CarsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Brands.GetAllBrands
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, List<BrandDTO>>
    {
        private readonly CarsDriversContext _carsDriversContext;
        
        public GetAllBrandsHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
        public async Task<List<BrandDTO>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var pushBrands = await _carsDriversContext.CarBrands
                .OrderBy(br => br.BrandName)
                .Select(br => new BrandDTO
                    {
                        BrandName = br.BrandName,
                        BrandId = br.BrandId
                        
                    }
                
                )
                .ToListAsync(cancellationToken);
            
            return pushBrands;
        }
    }
}
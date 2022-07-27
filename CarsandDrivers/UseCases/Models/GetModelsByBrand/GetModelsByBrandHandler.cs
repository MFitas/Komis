using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.UseCases.Models.ModelsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Models.GetModelsByBrand
{
    public class GetModelsByBrandHandler : IRequestHandler<GetModelsByBrandQuery, List<ModelDTO>>
    {
        private readonly CarsDriversContext _carsDriversContext;
        
        public GetModelsByBrandHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
        public async Task<List<ModelDTO>> Handle(GetModelsByBrandQuery request, CancellationToken cancellationToken)
        {
            var pushModels = await _carsDriversContext.CarModels
                .OrderBy(md => md.Brand.BrandName)
                .ThenBy(md => md.ModelName)
                .Select(md => new ModelDTO
                {
                    BrandName = md.Brand.BrandName,
                    ModelName = md.ModelName,
                    ModelId = md.ModelId
                })
                .Where(md => md.BrandName == request.BrandName)
                .ToListAsync(cancellationToken);

            return pushModels;
        }
    }
}
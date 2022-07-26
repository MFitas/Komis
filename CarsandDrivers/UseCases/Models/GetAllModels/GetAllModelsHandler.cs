using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Models.ModelsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Models
{
    public class GetAllModelsHandler : IRequestHandler<GetAllModelsQuery, List<ModelDTO>>
    {
        private readonly CarsDriversContext _carsDriversContext;
        
        public GetAllModelsHandler(CarsDriversContext context)
         {
             _carsDriversContext = context;
       }
        
        public async Task<List<ModelDTO>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
        {
            var pushModels = await _carsDriversContext.CarModels
                .OrderBy(md => md.Brand.BrandName)
                .ThenBy(md => md.ModelName)
                .Select(md => new ModelDTO
                {
                    ModelName = md.ModelName
                }).ToListAsync(cancellationToken);

            return pushModels;
        }
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Models.ModelsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Models.GetModelById
{
    public class GetModelByIdHandler : IRequestHandler<GetModelByIdQuery, ModelDTO>
    {
        private readonly CarsDriversContext _carsDriversContext;
        
        public GetModelByIdHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
        public async Task<ModelDTO> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            var pushModel = await _carsDriversContext.CarModels
                .Select(md => new ModelDTO
                {
                    ModelName = md.ModelName,
                    ModelId = md.ModelId
                }).FirstOrDefaultAsync(cancellationToken);
            
            return pushModel;
        }
    }
}
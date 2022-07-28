using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.Infrastructure.Entities;
using MediatR;
using Newtonsoft.Json;

namespace CarsAndDrivers.UseCases.Models.ImportModels
{
    public class ImportModelsHandler : IRequestHandler<ImportModelsCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;
        public ImportModelsHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }   
        
        public async Task<Unit> Handle(ImportModelsCommand request, CancellationToken cancellationToken)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(request.TableOfModelsFile.OpenReadStream()))
            {
                while (reader.Peek()>=0)
                {
                    result.AppendLine(await reader.ReadToEndAsync());
                }
            }

            var modelSerialize = JsonConvert.DeserializeObject<ModelSerialize>(result.ToString());
            
            foreach (var carModel in modelSerialize.CarModels)
            {
                var newModel = new CarModel
                {
                    BrandId = _carsDriversContext.CarBrands.Local.First(x=>x.BrandName == request.BrandName).BrandId,
                    ModelName = carModel
                };
            
                _carsDriversContext.CarModels.Add(newModel);
            }

            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }

    }
}
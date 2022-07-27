using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.Infrastructure.Entities;
using MediatR;
using Newtonsoft.Json;

namespace CarsAndDrivers.UseCases.Brands.ImportBrands
{
    public class ImportBrandsHandler : IRequestHandler<ImportBrandsCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public ImportBrandsHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
        public async Task<Unit> Handle(ImportBrandsCommand request, CancellationToken cancellationToken)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(request.TableOfBrandsFile.OpenReadStream()) )
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            var brandsSerialize = JsonConvert.DeserializeObject<BrandsSerialize>(result.ToString());

            foreach (var carBrand in brandsSerialize.CarBrands)
            {
                var newBrand = new CarBrand
                {
                    BrandName = carBrand
                };

                _carsDriversContext.CarBrands.Add(newBrand);
            }

            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
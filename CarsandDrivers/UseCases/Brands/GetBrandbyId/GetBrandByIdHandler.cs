using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Brands.BrandsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Brands.GetBrandById
{
    public class GetBrandByIdHandler: IRequestHandler<GetBrandByIdQuery, BrandDTO>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public GetBrandByIdHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<BrandDTO> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var pushBrand = await _carsDriversContext.CarBrands
                .Select(br => new BrandDTO
                {
                    BrandName = br.BrandName,
                    BrandId = br.BrandId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return pushBrand;
        }
    }
}
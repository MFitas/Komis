using CarsAndDrivers.UseCases.Brands.BrandsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Brands.GetBrandbyId
{
    public class GetBrandByIdQuery : IRequest<BrandDTO>
    {
        public int Id { get; set; }
    }
}
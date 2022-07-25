using CarsAndDrivers.UseCases.Brands.BrandsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Brands.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<BrandDTO>
    {
        public int Id { get; set; }
    }
}
using MediatR;

namespace CarsAndDrivers.UseCases.Brands.AddBrand
{
    public class AddBrandCommand : IRequest
    {
        public string BrandName { get; set; }
    }
}
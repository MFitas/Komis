using MediatR;

namespace CarsAndDrivers.UseCases.Brands.RemoveBrand
{
    public class RemoveBrandByIdCommand :IRequest
    {
        public int Id { get; set; }
    }
}
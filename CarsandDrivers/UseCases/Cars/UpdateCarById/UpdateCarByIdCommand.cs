using MediatR;

namespace CarsAndDrivers.UseCases.Cars.UpdateCarById
{
    public class UpdateCarByIdCommand : IRequest
    {
        public int Id;
        
        public string BrandName { get; set; }
        
        public string ModelName { get; set; }
    }
}
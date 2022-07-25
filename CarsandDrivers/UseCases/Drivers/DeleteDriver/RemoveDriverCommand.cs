using MediatR;

namespace CarsAndDrivers.UseCases.Drivers.DeleteDriver
{
    public record RemoveDriverCommand : IRequest
    {
        public int Id { get; set; }
    }

    

}
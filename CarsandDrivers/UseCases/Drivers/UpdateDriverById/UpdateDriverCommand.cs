using MediatR;

namespace CarsAndDrivers.UseCases.Drivers.UpdateDriverById
{
    public record UpdateDriverCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Occupation { get; set; }
    }
}
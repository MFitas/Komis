using MediatR;

namespace CarsAndDrivers.UseCases.Drivers.CreateDriver
{
    public class AddDriverCommand : IRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Occupation { get; set; }
    }





}
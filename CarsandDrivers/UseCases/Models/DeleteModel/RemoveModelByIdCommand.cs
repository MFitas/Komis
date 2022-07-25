using MediatR;

namespace CarsAndDrivers.UseCases.Models.DeleteModel
{
    public class RemoveModelByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}
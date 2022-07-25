using CarsAndDrivers.UseCases.Models.ModelsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Models.GetModelById
{
    public class GetModelByIdQuery : IRequest<ModelDTO>
    {
        public int Id { get; set; }
    }
}
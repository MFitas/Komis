using System.Collections.Generic;
using CarsAndDrivers.UseCases.Models.ModelsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Models
{
    public class GetAllModelsQuery : IRequest<List<ModelDTO>>
    {

    }
}
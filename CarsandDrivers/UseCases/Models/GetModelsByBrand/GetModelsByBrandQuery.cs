using System.Collections.Generic;
using CarsAndDrivers.UseCases.Models.ModelsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Models.GetModelsByBrand
{
    public class GetModelsByBrandQuery : IRequest<List<ModelDTO>>
    {
        public string BrandName { get; set; }
    }
}
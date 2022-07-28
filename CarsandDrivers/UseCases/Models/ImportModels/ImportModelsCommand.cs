using MediatR;
using Microsoft.AspNetCore.Http;

namespace CarsAndDrivers.UseCases.Models.ImportModels
{
    public class ImportModelsCommand : IRequest
    {
        public string BrandName { get; set; }
        public IFormFile TableOfModelsFile { get; set; }
    }
}
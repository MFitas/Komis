using MediatR;
using Microsoft.AspNetCore.Http;

namespace CarsAndDrivers.UseCases.Models.ImportModels
{
    public class ImportModelsCommand : IRequest
    {
        public int BrandId { get; set; }
        public IFormFile TableOfModelsFile { get; set; }
    }
}
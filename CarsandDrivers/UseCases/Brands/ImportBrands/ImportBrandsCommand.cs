using System.IO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CarsAndDrivers.UseCases.Brands.ImportBrands
{
    public class ImportBrandsCommand : IRequest
    {
        public IFormFile TableOfBrandsFile { get; set; }
    }
}
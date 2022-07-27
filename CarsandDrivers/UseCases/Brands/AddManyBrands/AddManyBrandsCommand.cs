using System.Collections.Generic;
using CarsAndDrivers.Infrastructure.Entities;
using CarsAndDrivers.UseCases.Brands.BrandsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Brands.AddManyBrands
{
    public class AddManyBrandsCommand : IRequest
    {
        public List<BrandDTOPost> BrandNames { get; set; }
    }
}
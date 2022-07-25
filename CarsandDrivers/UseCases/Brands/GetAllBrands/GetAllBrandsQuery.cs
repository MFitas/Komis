using System.Collections.Generic;
using CarsAndDrivers.UseCases.Brands.BrandsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Brands.GetAllBrands
{
    public class GetAllBrandsQuery : IRequest<List<BrandDTO>>
    {
        
    }
}
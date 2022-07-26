using CarsAndDrivers.UseCases.Brands.BrandsModels;
using MediatR;

namespace CarsAndDrivers.UseCases.Models.CreateModel
{
    public class AddModelCommand :  IRequest<Unit>
    {
        public string ModelName { get; set; }
        
        public string BrandName { get; set; }
    }
}
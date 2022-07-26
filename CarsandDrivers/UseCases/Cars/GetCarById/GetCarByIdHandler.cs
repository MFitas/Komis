using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Cars.CarsModels;
using CarsAndDrivers.UseCases.Cars.GetAllCars;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Cars.GetCarById
{
    
        public class GetCarByIdHandler : IRequestHandler<GetCarByIdQuery, CarDTO>
        {
            private readonly CarsDriversContext _carsDriversContext;
        
            public GetCarByIdHandler(CarsDriversContext context)
            {
                _carsDriversContext = context;
            }

            public async Task<CarDTO> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
            {
                var pushCar = await _carsDriversContext.Cars
                    .Select(cr => new CarDTO
                    {
                        BrandName = cr.Model.Brand.BrandName,
                        ModelName = cr.Model.ModelName,
                        CarId = cr.CarId,
                        OwnersId = cr.Drivers
                            .Select(x=>x.DriverId)
                            .ToList()
                    }).FirstOrDefaultAsync(cancellationToken);
                
                return pushCar;
            }
        }
}
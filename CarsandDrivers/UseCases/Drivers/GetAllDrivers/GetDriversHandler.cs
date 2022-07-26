using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Entities;
using CarsAndDrivers.UseCases.Cars.CarsModels;
using CarsAndDrivers.UseCases.Drivers.DriversModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Drivers.GetAllDrivers
{
    public class GetDriversHandler : IRequestHandler<GetAllDriversQuery, List<DriverDTO>>
    {
        // polaczenie  z baza?
        private readonly CarsDriversContext _carsDriversContext;

        public GetDriversHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
        public async Task<List<DriverDTO>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
         
                var pushdrivers = await _carsDriversContext.Drivers
                    .OrderBy(dr => dr.SecondName)
                    .ThenBy(dr => dr.FirstName)
                    .Select(dr => new DriverDTO
                    {
                        FirstName = dr.FirstName,
                        SecondName = dr.SecondName,
                        Occupation = dr.Occupation,
                        CarInfo = dr.Cars
                            .Select(cr => new CarDTO()
                            {
                                BrandName = cr.Model.Brand.BrandName,
                                ModelName = cr.Model.ModelName,
                               
                                

                            })
                            .ToList()

                    }).ToListAsync(cancellationToken);
            

            return pushdrivers ;
        }
    }
}
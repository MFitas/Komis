using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.Infrastructure;
using CarsAndDrivers.UseCases.Drivers.DriversModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Drivers.DriverGetById
{
    public class GetDriverHandler : IRequestHandler<GetDriverQuery, DriverWithoutCarDTO>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public GetDriverHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<DriverWithoutCarDTO> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var pushDriver = await _carsDriversContext.Drivers
                .Where(dr => dr.DriverId == request.Id)
                .Select(dr => new DriverWithoutCarDTO
                {
                    FirstName = dr.FirstName,
                    SecondName = dr.SecondName,
                    Occupation = dr.Occupation,
                    DriverId = dr.DriverId
                })
                .FirstOrDefaultAsync(cancellationToken);
            
            return pushDriver;
        }
    }
}
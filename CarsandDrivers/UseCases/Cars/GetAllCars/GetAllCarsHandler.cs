// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using CarsAndDrivers.UseCases.Cars.CarsModels;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace CarsAndDrivers.UseCases.Cars.GetAllCars
// {
//     public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, List<CarDTO>>
//     {
//         private readonly CarsDriversContext _carsDriversContext;
//         
//         public GetAllCarsHandler(CarsDriversContext context)
//         {
//             _carsDriversContext = context;
//         }
//
//         public async Task<List<CarDTO>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
//         {
//             var pushCars = await _carsDriversContext.Cars
//                 .OrderBy(cr => cr.Brand)
//                 .ThenBy(cr => cr.Model)
//                 .Select(cr => new CarDTO
//                 {
//                     Brand = cr.Brand,
//                     Model = cr.Model,
//                     OwnersId = cr.Drivers
//                         .Select(x=>x.DriverId)
//                         .ToList()
//                     
//                 }).ToListAsync(cancellationToken);
//             
//             return pushCars;
//         }
//     }
// }
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Cars;
using CarsAndDrivers.UseCases.Cars.CarAssignment;
using CarsAndDrivers.UseCases.Cars.CarsModels;
using CarsAndDrivers.UseCases.Cars.CreateCar;
using CarsAndDrivers.UseCases.Cars.DeleteCar;
using CarsAndDrivers.UseCases.Cars.GetAllCars;
using CarsAndDrivers.UseCases.Cars.GetCarById;
using CarsAndDrivers.UseCases.Cars.UpdateCarById;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CarsAndDrivers.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarsController : ControllerBase
    {
        
        /// <summary>
        /// Creates new Car
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddCar([FromServices]IMediator mediator,
            [FromBody] AddCarCommand command)
        {
            await mediator.Send(command);
            
            return Ok();
        }
        
        /// <summary>
        /// Returns all available cars
        /// </summary>
        /// <returns>all available cars</returns>
        [HttpGet]
        public async Task<ActionResult<List<CarDTO>>> GetAllCars([FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var allCars = await mediator.Send(new GetAllCarsQuery(),cancellationToken);

            return Ok(allCars);
        }
        
        
        /// <summary>
        /// returns car wth specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>car with specified id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneCarById
            ([FromServices] IMediator mediator,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            var oneCar = await mediator.Send(new GetCarByIdQuery
            {
                Id = id
            });
            
            return Ok(oneCar);
        }
        
        /// <summary>
        /// Removes Car with specified id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveCarById(
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken,
            int id)
        {
            await mediator.Send(new RemoveCarByIdCommand
            {
                Id = id
            });

            return Ok();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCarById(
            [FromServices] IMediator mediator,
            [FromRoute] int id,
            [FromBody] UpdateCarByIdCommandApi command,
            CancellationToken cancellationToken)
        {
            await mediator.Send(new UpdateCarByIdCommand
            {
                Id = id,
                BrandName = command.BrandName,
                ModelName = command.ModelName
                    
            }, cancellationToken);

            return Ok();
        }
        
        //Carassigment
        [HttpPut("{id}/AssignDriver")]
        public async Task<ActionResult> AssignDriver(
            [FromServices] IMediator mediator,
            [FromRoute] int id,
            [FromBody] CarAssignmentCommandBody body,
            CancellationToken cancellationToken)
        {
            await mediator.Send(new CarAssignmentCommand
            {
                CarId = id,
                DriverId = body.DriverId
                    
            });
            
            return Ok();
        }
        
    }
}
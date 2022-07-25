using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Cars;
using CarsAndDrivers.UseCases.Cars.CreateCar;
using CarsAndDrivers.UseCases.Cars.DeleteCar;
using CarsAndDrivers.UseCases.Cars.GetAllCars;
using CarsAndDrivers.UseCases.Cars.GetCarById;
using CarsAndDrivers.UseCases.Cars.UpdateCarById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarsAndDrivers.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarsController : ControllerBase
    {
        
        //CREATE CAR
        [HttpPost]
        public async Task<ActionResult> AddCar([FromServices]IMediator mediator,
            [FromBody] AddCarCommand command)
        {
            await mediator.Send(command);
            
            return Ok();
            
        }
        
        //GETALLCARS
        [HttpGet]

        public async Task<ActionResult> GetAllCars([FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var allCars = await mediator.Send(new GetAllCarsQuery(),cancellationToken);

            return Ok(allCars);
        }
        
        //GETONECAR
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneCarById
            ([FromServices] IMediator mediator,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            var oneCar = await mediator.Send(new GetCarByIdQuery
            {
                id = id
            });
            
            return Ok(oneCar);
        }
        
        //DELETECAR
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
        
        //UPDATECAR
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
                Brand = command.Brand,
                Model = command.Model
                    
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
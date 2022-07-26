using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Models;
using CarsAndDrivers.UseCases.Models.CreateModel;
using CarsAndDrivers.UseCases.Models.DeleteModel;
using CarsAndDrivers.UseCases.Models.GetAllModels;
using CarsAndDrivers.UseCases.Models.GetModelById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarsAndDrivers.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ModelsController : ControllerBase
    {
        //Create Model
        [HttpPost]
        public async Task<ActionResult> AddModel([FromServices]IMediator mediator,
            [FromBody] AddModelCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command);
            
            return Ok();
            
        }
        
        //GETALLMODELS
        [HttpGet]

        public async Task<ActionResult> GetAllModels([FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var allCars = await mediator.Send(new GetAllModelsQuery(),cancellationToken);

            return Ok(allCars);
        }
        
        
        //GETONECAR
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneModelById
        ([FromServices] IMediator mediator,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            var oneCar = await mediator.Send(new GetModelByIdQuery()
            {
                Id = id
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
            await mediator.Send(new RemoveModelByIdCommand()
            {
                Id = id
            });

            return Ok();
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Models;
using CarsAndDrivers.UseCases.Models.CreateModel;
using CarsAndDrivers.UseCases.Models.DeleteModel;
using CarsAndDrivers.UseCases.Models.GetAllModels;
using CarsAndDrivers.UseCases.Models.GetModelById;
using CarsAndDrivers.UseCases.Models.GetModelsByBrand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarsAndDrivers.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ModelsController : ControllerBase
    {
        /// <summary>
        /// Creates new Model for a brand
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddModel([FromServices]IMediator mediator,
            [FromBody] AddModelCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command);
            
            return Ok();
            
        }
        
        /// <summary>
        /// Returns all Models
        /// </summary>
        /// <returns>all Models</returns>
        [HttpGet]
        public async Task<ActionResult> GetAllModels([FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var allCars = await mediator.Send(new GetAllModelsQuery(),cancellationToken);

            return Ok(allCars);
        }
        
        
        /// <summary>
        /// Returns Model with specified id
        /// </summary>
        /// <returns>Model with specified id</returns>
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
        
        /// <summary>
        /// Removes model with given id from he database
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveModelById(
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

        /// <summary>
        /// Returns all Models of the specified Brand
        /// </summary>
        /// <returns>all Models of the specified Brand</returns>
        [HttpGet("{brandName}1")]
        public async Task<ActionResult> GetModelsByBrand(
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken,
                string brandName)
        {
            var allModelsFromOneBrand= await mediator.Send(new GetModelsByBrandQuery
            {
                BrandName = brandName
            });
            
            return Ok(allModelsFromOneBrand);
        }
    }
}
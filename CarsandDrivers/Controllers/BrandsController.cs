using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Brands.AddBrand;
using CarsAndDrivers.UseCases.Brands.GetAllBrands;
using CarsAndDrivers.UseCases.Brands.GetBrandById;
using CarsAndDrivers.UseCases.Brands.RemoveBrand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarsAndDrivers.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BrandsController : ControllerBase
    {
        //Create Brand
        [HttpPost]
        public async Task<ActionResult> AddBrand([FromServices]IMediator mediator,
            [FromBody] AddBrandCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            
            return Ok();
            
        }
        
        //GETALLBrands
        [HttpGet]

        public async Task<ActionResult> GetAllBrands([FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var allBrands = await mediator.Send(new GetAllBrandsQuery(),cancellationToken);

            return Ok(allBrands);
        }
        
        
        //GETONEBrand
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneBrandById
        ([FromServices] IMediator mediator,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            var oneBrand = await mediator.Send(new GetBrandByIdQuery()
            {
                Id = id
            }, cancellationToken);
            
            return Ok(oneBrand);
        }
        
        //DELETEBrand
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveBrandById(
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken,
            int id)
        {
            await mediator.Send(new RemoveBrandByIdCommand()
            {
                Id = id
            }, cancellationToken);

            return Ok();
        }
    }
}
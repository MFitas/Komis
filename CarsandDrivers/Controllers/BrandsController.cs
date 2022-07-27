using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Brands.AddBrand;
using CarsAndDrivers.UseCases.Brands.AddManyBrands;
using CarsAndDrivers.UseCases.Brands.GetAllBrands;
using CarsAndDrivers.UseCases.Brands.GetBrandbyId;
using CarsAndDrivers.UseCases.Brands.ImportBrands;
using CarsAndDrivers.UseCases.Brands.RemoveBrand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAndDrivers.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BrandsController : ControllerBase
    {
        /// <summary>
        /// Creates new Brand
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddBrand([FromServices]IMediator mediator,
            [FromBody] AddBrandCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            
            return Ok();
            
        }
        
        /// <summary>
        /// Returns all available Brands 
        /// </summary>
        /// <returns>all available Brands</returns>
        [HttpGet]

        public async Task<ActionResult> GetAllBrands([FromServices] IMediator mediator,
            CancellationToken cancellationToken)
        {
            var allBrands = await mediator.Send(new GetAllBrandsQuery(),cancellationToken);

            return Ok(allBrands);
        }
        
        
        /// <summary>
        /// Returns a Brand with specified id
        /// </summary>
        /// <returns>Brand with given id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOneBrandById
        ([FromServices] IMediator mediator,
            [FromRoute] int id,
            CancellationToken cancellationToken)
        {
            var oneBrand = await mediator.Send(new GetBrandByIdQuery
            {
                Id = id
            }, cancellationToken);
            
            return Ok(oneBrand);
        }
        
        /// <summary>
        /// Removes a Brand from database
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveBrandById(
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken,
            int id)
        {
            await mediator.Send(new RemoveBrandByIdCommand
            {
                Id = id
            }, cancellationToken);

            return Ok();
        }

        [HttpPost("many")]
        public async Task<ActionResult> AddManyBrands(
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken,
            [FromBody] AddManyBrandsCommand command)
        {
            await mediator.Send(new AddManyBrandsCommand
            {
                BrandNames = command.BrandNames
            }, cancellationToken);
            
            return Ok();
        }

        [HttpPost("import")]
        public async Task<ActionResult> ImportDatabase(
            [FromServices] IMediator mediator,
            IFormFile formFile,
            CancellationToken cancellationToken)
        {
            

            await mediator.Send(new ImportBrandsCommand
            {
                TableOfBrandsFile = formFile
            }, cancellationToken);
            
            return Ok();
        }
        
    }
}
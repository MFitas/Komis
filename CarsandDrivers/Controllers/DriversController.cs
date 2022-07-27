using System.Threading;
using System.Threading.Tasks;
using CarsAndDrivers.UseCases.Drivers.CreateDriver;
using CarsAndDrivers.UseCases.Drivers.DeleteDriver;
using CarsAndDrivers.UseCases.Drivers.DriverGetById;
using CarsAndDrivers.UseCases.Drivers.GetAllDrivers;
using CarsAndDrivers.UseCases.Drivers.UpdateDriverById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarsAndDrivers.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DriversController : ControllerBase
    {
        private readonly IMediator _mediatorDrivers; //mediator
        

        public DriversController( IMediator mediatorDrivers)
        {
            _mediatorDrivers = mediatorDrivers;
        }
        
        /// <summary>
        /// Returns all available Drivers
        /// </summary>
        /// <returns>all available Drivers</returns>
        [HttpGet]
        public async Task<ActionResult> GetDrivers(CancellationToken cancellationToken)
        {
            var drivers = await _mediatorDrivers.Send(new GetAllDriversQuery(), cancellationToken);
            return Ok(drivers);
        }
        
      /// <summary>
      /// Returns driver with specified id
      /// </summary>
     /// <returns>driver with specified id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDriver(int id, CancellationToken cancellationToken)
        {
            var driver = await _mediatorDrivers.Send(new GetDriverQuery
            {
                Id = id
            }, cancellationToken);
            return Ok(driver);
        }
        
        /// <summary>
        /// Creates a new Driver
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> AddDriver([FromBody] AddDriverCommand command, 
            CancellationToken cancellationToken)
        {
            await _mediatorDrivers.Send(command, cancellationToken );
            
                return Ok();
            
        }

        /// <summary>
        /// Removes Driver with specified id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveDriver([FromRoute] int id,
            CancellationToken cancellationToken)
        {
             await _mediatorDrivers.Send(new RemoveDriverCommand
             {
                 Id = id
             }, cancellationToken);

            return Ok();
        }
        
        /// <summary>
        /// Updates data of the Driver with given id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDriver([FromRoute]int id,
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] UpdateDriverCommandApi command,
            CancellationToken cancellationToken)
        {
            
            await _mediatorDrivers.Send(new UpdateDriverCommand
            {
                Id = id,
                FirstName = command.FirstName,
                SecondName = command.SecondName,
                Occupation = command.Occupation
            }, cancellationToken);

            return Ok();
        }

    }
}
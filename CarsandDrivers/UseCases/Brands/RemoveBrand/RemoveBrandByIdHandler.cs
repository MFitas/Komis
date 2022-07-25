using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Brands.RemoveBrand
{
    public class RemoveBrandByIdHandler : IRequestHandler<RemoveBrandByIdCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public RemoveBrandByIdHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }
        
        public async Task<Unit> Handle(RemoveBrandByIdCommand command, CancellationToken cancellationToken)
        {
            var brandToRemove =  await _carsDriversContext.Cars
                .Where(cr => cr.BrandId == command.Id)
                .FirstOrDefaultAsync(cancellationToken);
            
            _carsDriversContext.Remove(brandToRemove);

            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarsAndDrivers.UseCases.Models.DeleteModel
{
    public class RemoveModelByIdHandler : IRequestHandler<RemoveModelByIdCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public RemoveModelByIdHandler(CarsDriversContext context)
        {
            _carsDriversContext = context;
        }

        public async Task<Unit> Handle(RemoveModelByIdCommand command, CancellationToken cancellationToken)
        {
            var modelToRemove = await _carsDriversContext.CarModels
                .Where(md => md.ModelId == command.Id)
                .FirstOrDefaultAsync(cancellationToken);

            _carsDriversContext.Remove(modelToRemove);
            await _carsDriversContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }

    }
}
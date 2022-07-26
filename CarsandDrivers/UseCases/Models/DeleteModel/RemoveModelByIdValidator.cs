using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Models.DeleteModel
{
    public class RemoveModelByIdValidator : ModelsValidator<RemoveModelByIdCommand>
    {
        public RemoveModelByIdValidator(CarsDriversContext carsDriversContext) : base(carsDriversContext)
        {
            RuleFor(md => md.Id)
                .NotEmpty()
                .WithMessage("Id cant be Empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())
                
                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithErrorCode(ErrorCode.NotFound.ToString());
        }
        
        public bool BeValidId(int id) =>
            _carsDriversContext.CarModels.FirstOrDefault(x => x.ModelId == id) != null;
    }
}
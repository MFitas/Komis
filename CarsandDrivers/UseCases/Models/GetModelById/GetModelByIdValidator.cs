using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Models.GetModelById
{
    public class GetModelByIdValidator : ModelsValidator<GetModelByIdQuery>
    {
        public GetModelByIdValidator(CarsDriversContext carsDriversContext) : base(carsDriversContext)
        {
            RuleFor(md => md.Id)
                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithErrorCode(ErrorCode.NotFound.ToString())

                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString());
        }
        
        public bool BeValidId(int id) =>
            _carsDriversContext.CarModels.FirstOrDefault(x => x.ModelId == id) != null;
    }
}
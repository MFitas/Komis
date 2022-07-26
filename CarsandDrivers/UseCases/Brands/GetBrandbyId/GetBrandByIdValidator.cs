using CarsAndDrivers.Infrastructure;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Brands.GetBrandbyId
{
    public class GetBrandByIdValidator : BrandValidator<GetBrandByIdQuery>
    {
        public GetBrandByIdValidator(CarsDriversContext context) : base(context)
        {
            RuleFor(gt => gt.Id)
                .NotEmpty()
                .WithMessage("Id cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString());
            
            RuleFor(br => br.Id)
                .Must(BeValidId)
                .WithMessage("Id not found")
                .WithMessage(ErrorCode.NotFound.ToString());
        }
    }
}
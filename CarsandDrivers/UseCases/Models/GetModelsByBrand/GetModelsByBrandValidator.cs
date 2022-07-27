using System.Linq;
using CarsAndDrivers.Infrastructure;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Models.GetModelsByBrand
{
    public class GetModelsByBrandValidator : ModelsValidator<GetModelsByBrandQuery>
    {
        public GetModelsByBrandValidator(CarsDriversContext carsDriversContext) : base(carsDriversContext)
        {
            RuleFor(md => md.BrandName)
                .NotEmpty()
                .WithMessage("Brand Name cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                .Must(BeValidBrand)
                .WithMessage("Brand not found")
                .WithErrorCode(ErrorCode.InvalidBrand.ToString());
        }

        public bool BeValidBrand(string brandName) =>
            _carsDriversContext.CarBrands.FirstOrDefault(x => x.BrandName == brandName) is not null;

    }
}
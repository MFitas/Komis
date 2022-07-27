using System.Linq;
using CarsAndDrivers.Infrastructure;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Models.GetAllModels
{
    public class GetAllModelsValidator : ModelsValidator<GetAllModelsQuery>
    {
        public GetAllModelsValidator(CarsDriversContext carsDriversContext) : base(carsDriversContext)
        {
            RuleFor(br => br.BrandId)
                .Must(BeValidBrand)
                .When(x => x.BrandId != null)
                .WithMessage("Invalid brand")
                .WithErrorCode(ErrorCode.InvalidBrand.ToString());
        }

        private bool BeValidBrand(int?brandId)
        {
            return _carsDriversContext.CarBrands.Any(x => x.BrandId == brandId);
        }
    }
}
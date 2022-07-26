using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Cars.CreateCar
{
    public class AddCarValidator : AbstractValidator<AddCarCommand>
    {
        private readonly CarsDriversContext _carsDriversContext;

        public AddCarValidator(CarsDriversContext carsDriversContext)
        {
            _carsDriversContext = carsDriversContext;

            ClassLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(br => br.BrandName)
                .NotEmpty().WithMessage("Field cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                .Must(BeValidBrand)
                .WithMessage("Brand does not exist")
                .WithErrorCode(ErrorCode.InvalidBrand.ToString())

                .MinimumLength(2)
                .WithMessage("Brand name is too Short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())
                
                .MaximumLength(50)
                .WithMessage("Brand name is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
            
            RuleFor(md=>md.ModelName)
                .NotEmpty()
                .WithMessage("Field cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())
                
                
                .Must(BeValid)
                .WithMessage("Model does not exist")
                .WithErrorCode(ErrorCode.InvalidModel.ToString())
                

                .MinimumLength(2)
                .WithMessage("Model name is too Short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())
                
                .MaximumLength(50)
                .WithMessage("Model name is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
        }

        private bool BeValid(string modelName)
        {
            return _carsDriversContext.CarModels.FirstOrDefault(x => x.ModelName == modelName) is not null;
        }

        private bool BeValidBrand(string brandName)
        {
            return _carsDriversContext.CarBrands.FirstOrDefault(x => x.BrandName == brandName) is not null;
        }

       
        
        
    }
}
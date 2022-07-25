using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace CarsAndDrivers.UseCases.Cars.CreateCar
{
    public class AddCarValidator : AbstractValidator<AddCarCommand>
    {
        
        public AddCarValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(br => br.Brand)
                .NotEmpty().WithMessage("Field cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                // .Must(BeValidBrand)
                // .WithMessage("Invalid Brand")
                // .WithErrorCode(ErrorCode.InvalidBrand.ToString())

                .MinimumLength(2)
                .WithMessage("Brand name is too Short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())
                
                .MaximumLength(50)
                .WithMessage("Brand name is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
            
            RuleFor(md=>md.Model)
                .NotEmpty().WithMessage("Field cant be empty")
                .WithErrorCode(ErrorCode.MissingRequiredField.ToString())

                // .Must((command, s) =>BeValidModel(s,command.Brand) )
                // .WithMessage("Invalid Model")
                // .WithErrorCode(ErrorCode.InvalidModel.ToString())

                .MinimumLength(2)
                .WithMessage("Model name is too Short")
                .WithErrorCode(ErrorCode.FieldTooShort.ToString())
                
                .MaximumLength(50)
                .WithMessage("Model name is too long")
                .WithErrorCode(ErrorCode.FieldTooLong.ToString());
        }

        // private bool BeValidModel(string model, string brand)
        // {
        //     var modelEnumType = CarModels.GetBrandModels(brand);
        //     return Enum.TryParse(modelEnumType, model, true, out _);
        // }
        //
        // private bool BeValidBrand(string brand)
        // {
        //     return Enum.TryParse<CarBrand>(brand,true,out  _);
        // }
    }
}
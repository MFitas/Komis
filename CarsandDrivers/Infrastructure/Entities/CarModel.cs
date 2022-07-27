using System.Collections.Generic;

namespace CarsAndDrivers.Infrastructure.Entities
{
    public class CarModel
    {
        public int ModelId { get; set; }
        
        public string ModelName { get; set; }
        
        public int BrandId { get; set; }

        public virtual CarBrand Brand { get; set; }
        
        public virtual ICollection<Car> Cars { get; set; }
        // public static Type GetBrandModels(CarBrand brand)
        // {
        //    var modelType =  typeof(CarModels).GetNestedTypes()
        //         .Single(x => x.Name == brand.ToString() + "Model");
        //    return modelType;
        // }
        // public static Type GetBrandModels(string brand)
        // {
        //     var brandEnum = Enum.Parse<CarBrand>(brand, true);
        //     return GetBrandModels(brandEnum);
        // }
        // public enum AudiModel
        // {
        //     A4,
        //     A6,
        //     A8,
        //     Q2
        // }
        //
        // public enum MercedesModel
        // {
        //     Vito,
        //     Atego,
        //     Vario,
        //     Sprinter
        // }
        //
        // public enum OpelModel
        // {
        //     Vectra
        // }
    }
}
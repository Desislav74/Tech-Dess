namespace TechDess.Web.ViewModels.Products
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ProductCharacteristicInputModel : IMapFrom<ProductCharacteristic>
    {
        public string CharacteristicName { get; set; }

        public string Model { get; set; }

        public string Resolution { get; set; }

        public decimal ScreenSizeInInches { get; set; }

        public string Color { get; set; }

        public int Memory { get; set; }

        public string Os { get; set; }

        public int Ram { get; set; }

        public int Weight { get; set; }
    }
}

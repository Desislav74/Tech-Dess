namespace TechDess.Data.Models
{
    public class ProductCharacteristic
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; }

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

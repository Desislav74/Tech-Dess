namespace TechDess.Data.Models
{
    using TechDess.Data.Common.Models;

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

        public decimal Weight { get; set; }

        public int Battery { get; set; }

        public string DualSim { get; set; }

        public string Wifi { get; set; }

        public string Technology { get; set; }

        public string D3 { get; set; }

        public int ReactionTime { get; set; }

        public int Illumination { get; set; }

        public int PrintingSpeed { get; set; }

        public string Format { get; set; }

        public int Capacity { get; set; }

        public decimal CoolingPower { get; set; }

        public decimal HeatingPower { get; set; }

        public string Speaker { get; set; }

        public string Microphone { get; set; }

        public string Gps { get; set; }

        public string Wlan { get; set; }

        public string CallNotificationsAndMessages { get; set; }
    }
}

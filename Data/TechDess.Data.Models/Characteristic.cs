namespace TechDess.Data.Models
{
    using System.Collections.Generic;

    using TechDess.Data.Common.Models;

    public class Characteristic : BaseDeletableModel<int>
    {
        public Characteristic()
        {
            this.Products = new HashSet<ProductCharacteristic>();
        }

        public string Name { get; set; }

        public virtual ICollection<ProductCharacteristic> Products { get; set; }
    }
}

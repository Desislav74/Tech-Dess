namespace TechDess.Data.Models
{
    using System.Collections.Generic;

    using TechDess.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Characteristics = new HashSet<ProductCharacteristic>();
        }

        public string Name { get; set; }

        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<ProductCharacteristic> Characteristics { get; set; }
    }
}

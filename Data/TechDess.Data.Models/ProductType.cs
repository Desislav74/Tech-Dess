namespace TechDess.Data.Models
{
    using System.Collections.Generic;

    using TechDess.Data.Common.Models;

    public class ProductType : BaseDeletableModel<int>
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

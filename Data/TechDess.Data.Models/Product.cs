namespace TechDess.Data.Models
{
    using TechDess.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}

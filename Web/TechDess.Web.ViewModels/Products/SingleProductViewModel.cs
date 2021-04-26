namespace TechDess.Web.ViewModels.Products
{
    using System.Collections.Generic;

    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class SingleProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<CharacteristicsViewModel> Characteristics { get; set; }
    }
}

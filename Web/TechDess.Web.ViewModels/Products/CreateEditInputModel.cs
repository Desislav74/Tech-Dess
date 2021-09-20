namespace TechDess.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TechDess.Data.Models;
    using TechDess.Services.Mapping;
    using TechDess.Web.ViewModels.ProductTypes;

    public class CreateEditInputModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public ProductType Type { get; set; }

        public IEnumerable<CharacteristicsViewModel> Characteristics { get; set; }

        public IEnumerable<ProductTypeDropDownViewModel> ProductTypes { get; set; }
    }
}

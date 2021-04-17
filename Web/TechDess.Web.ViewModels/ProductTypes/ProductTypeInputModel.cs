namespace TechDess.Web.ViewModels.ProductTypes
{
    using System.ComponentModel.DataAnnotations;

    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ProductTypeInputModel : IMapFrom<ProductType>
    {
        [Required]
        public string Name { get; set; }
    }
}

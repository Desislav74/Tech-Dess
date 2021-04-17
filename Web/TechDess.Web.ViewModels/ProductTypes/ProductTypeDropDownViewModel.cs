namespace TechDess.Web.ViewModels.ProductTypes
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ProductTypeDropDownViewModel : IMapFrom<ProductType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

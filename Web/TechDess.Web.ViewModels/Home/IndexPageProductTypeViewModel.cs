namespace TechDess.Web.ViewModels.Home
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class IndexPageProductTypeViewModel : IMapFrom<ProductType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

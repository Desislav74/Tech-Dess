using Microsoft.AspNetCore.Http;
using TechDess.Data.Models;
using TechDess.Services.Mapping;

namespace TechDess.Web.ViewModels.Products
{
    public class ProductInListViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }
    }
}

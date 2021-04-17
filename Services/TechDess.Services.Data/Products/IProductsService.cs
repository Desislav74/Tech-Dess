using TechDess.Web.ViewModels.Products;

namespace TechDess.Services.Data.Products
{
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task<int> CreateAsync(string name, decimal price, int productTypeId, string image);
    }
}

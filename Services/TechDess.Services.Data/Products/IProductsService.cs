namespace TechDess.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TechDess.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task<int> CreateAsync(string name, decimal price, int productTypeId, string image);

        IEnumerable<T> GetByProductTypes<T>(int id, int page, int itemsPerPage = 6);

        int GetCount();
    }
}

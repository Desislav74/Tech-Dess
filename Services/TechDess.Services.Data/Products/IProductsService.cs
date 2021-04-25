namespace TechDess.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TechDess.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task<int> CreateAsync(ProductCreateInputModel input, string image);

        IEnumerable<T> GetByProductTypes<T>(int id, int page, int itemsPerPage = 6);

        T GetById<T>(int id);

        int GetCount();
    }
}

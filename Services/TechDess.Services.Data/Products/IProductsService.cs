namespace TechDess.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TechDess.Data.Models;
    using TechDess.Web.ViewModels.Products;

    public interface IProductsService
    {
        Task<int> CreateAsync(ProductCreateInputModel input, string image);

        IEnumerable<T> GetByProductTypes<T>(int id, int page, int itemsPerPage = 6);

        IEnumerable<T> GetByCharacteristics<T>(IEnumerable<int> characteristicIds);

        T GetById<T>(int id);

        IEnumerable<T> SearchByTerm<T>(string searchTerm);

        int GetCount();

        IEnumerable<T> GetAllIncreasing<T>(int id, int page, int itemsPerPage = 8);

        IEnumerable<T> GetAllDecreasing<T>(int id, int page, int itemsPerPage = 8);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, CreateEditInputModel input);
    }
}

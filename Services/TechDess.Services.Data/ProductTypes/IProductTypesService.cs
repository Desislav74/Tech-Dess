namespace TechDess.Services.Data.ProductTypes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TechDess.Web.ViewModels.ProductTypes;

    public interface IProductTypesService
    {
        Task CreateAsync(ProductTypeInputModel input);

        IEnumerable<T> GetAll<T>(int? count = null);
    }
}

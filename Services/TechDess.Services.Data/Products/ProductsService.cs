using System.Threading.Tasks;
using TechDess.Data.Common.Repositories;
using TechDess.Data.Models;
using TechDess.Services.Data.Cloudinary;
using TechDess.Web.ViewModels.Products;

namespace TechDess.Services.Data.Products
{
   public class ProductsService : IProductsService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;

        public ProductsService(IDeletableEntityRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<int> CreateAsync(string name, decimal price, int productTypeId, string image)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                ProductTypeId = productTypeId,
                Image = image,
            };
            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();
            return product.Id;
        }
    }
}

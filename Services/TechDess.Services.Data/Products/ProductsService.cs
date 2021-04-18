namespace TechDess.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Services.Data.Cloudinary;
    using TechDess.Services.Mapping;
    using TechDess.Web.ViewModels.Products;

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

        public IEnumerable<T> GetByProductTypes<T>(int id, int page, int itemsPerPage = 8)
        {
            var query = this.productRepository.All().AsQueryable()
                .Where(x => x.ProductTypeId == id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return query;
        }

        public T GetById<T>(int id)
        {
            var product = this.productRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return product;
        }

        public int GetCount()
        {
            return this.productRepository.All().Count();
        }
    }
}

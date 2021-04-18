namespace TechDess.Services.Data.ProductTypes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;
    using TechDess.Web.ViewModels.ProductTypes;

    public class ProducTypesService : IProductTypesService
    {
        private readonly IDeletableEntityRepository<ProductType> productTypeRepository;

        public ProducTypesService(IDeletableEntityRepository<ProductType> productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository;
        }

        public async Task CreateAsync(ProductTypeInputModel input)
        {
            var productType = new ProductType()
            {
                Name = input.Name,
            };
            await this.productTypeRepository.AddAsync(productType);
            await this.productTypeRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.productTypeRepository.All()
                .OrderBy(x =>x.Name)
                .To<T>().ToList();
        }
    }
}

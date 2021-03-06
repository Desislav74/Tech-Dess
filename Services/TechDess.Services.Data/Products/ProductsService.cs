namespace TechDess.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Services.Data.Cloudinary;
    using TechDess.Services.Mapping;
    using TechDess.Web.ViewModels.Products;

    public class ProductsService : IProductsService
   {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly IDeletableEntityRepository<Characteristic> characteristicRepository;

        public ProductsService(IDeletableEntityRepository<Product> productRepository, IDeletableEntityRepository<Characteristic> characteristicRepository)
        {
            this.productRepository = productRepository;
            this.characteristicRepository = characteristicRepository;
        }

        public async Task<int> CreateAsync(ProductCreateInputModel input, string image)
        {
            var product = new Product
            {
                Name = input.Name,
                Price = input.Price,
                ProductTypeId = input.ProductTypeId,
                Image = image,
                ProductType = input.Type,
            };

            foreach (var inputCharacteristic in input.Characteristics)
            {
                var characteristic = this.characteristicRepository.All()
                    .FirstOrDefault(x => x.Name == inputCharacteristic.CharacteristicName);
                if (characteristic == null)
                {
                    characteristic = new Characteristic() { Name = inputCharacteristic.CharacteristicName };
                }

                product.Characteristics.Add(new ProductCharacteristic()
                {
                    Characteristic = characteristic,
                    Model = inputCharacteristic.Model,
                    Weight = inputCharacteristic.Weight,
                    Ram = inputCharacteristic.Ram,
                    Memory = inputCharacteristic.Memory,
                    Os = inputCharacteristic.Os,
                    Resolution = inputCharacteristic.Resolution,
                    Color = inputCharacteristic.Color,
                    ScreenSizeInInches = inputCharacteristic.ScreenSizeInInches,
                    Battery = inputCharacteristic.Battery,
                    DualSim = inputCharacteristic.DualSim,
                    Wifi = inputCharacteristic.Wifi,
                    Technology = inputCharacteristic.Technology,
                    D3 = inputCharacteristic.D3,
                    ReactionTime = inputCharacteristic.ReactionTime,
                    Illumination = inputCharacteristic.Illumination,
                    PrintingSpeed = inputCharacteristic.PrintingSpeed,
                    Format = inputCharacteristic.Format,
                    Capacity = inputCharacteristic.Capacity,
                    CoolingPower = inputCharacteristic.CoolingPower,
                    HeatingPower = inputCharacteristic.HeatingPower,
                    Speaker = inputCharacteristic.Speaker,
                    Microphone = inputCharacteristic.Microphone,
                    Gps = inputCharacteristic.Gps,
                    Wlan = inputCharacteristic.Wlan,
                    CallNotificationsAndMessages = inputCharacteristic.CallNotificationsAndMessages,
                });
            }

            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();
            return product.Id;
        }

        public IEnumerable<T> GetByProductTypes<T>(int id, int page, int itemsPerPage = 8)
        {
            var query = this.productRepository.All().AsQueryable()
                .Where(x => x.ProductTypeId == id)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return query;
        }

        public IEnumerable<T> GetByCharacteristics<T>(IEnumerable<int> characteristicIds)
        {
            var query = this.productRepository.All().AsQueryable();
            foreach (var characteristicId in characteristicIds)
            {
                query = query.Where(x => x.Characteristics.Any(i => i.CharacteristicId == characteristicId));
            }

            return query.To<T>().ToList();
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

        public IEnumerable<T> GetAllIncreasing<T>(int id, int page, int itemsPerPage = 8)
        {
            var products = this.productRepository.All()
                .Where(x => x.ProductTypeId == id)
                .OrderBy(x => x.Price)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return products;
        }

        public IEnumerable<T> GetAllDecreasing<T>(int id, int page, int itemsPerPage = 8)
        {
            var products = this.productRepository.All()
                .Where(x => x.ProductTypeId == id)
                .OrderByDescending(x => x.Price)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return products;
        }

        public IEnumerable<T> SearchByTerm<T>(string searchTerm)
        {
            var searchText = searchTerm.Split(' ', '-', ':', ',', ';');
            var result = string.Concat(searchText).ToLower();
            var products = this.productRepository.All().AsQueryable().Where(x => (x.ProductType.Name + x.Name).ToLower().Contains(result)
                    || x.ProductType.Name.ToLower().Contains(result)
                    || x.Name.ToLower().Contains(result)
                    || x.Price.ToString().Contains(result)
                    || (x.Name + x.ProductType.Name).ToLower().Contains(result))
                .To<T>().ToList();
            return products;
        }

        public async Task DeleteAsync(int id)
        {
            var product =
                await this.productRepository
                    .All()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            this.productRepository.Delete(product);
            await this.productRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CreateEditInputModel input)
        {
            var product = this.productRepository.All().FirstOrDefault(x => x.Id == id);
            product.Name = input.Name;
            product.ProductTypeId = input.ProductTypeId;
            product.Price = input.Price;
            await this.productRepository.SaveChangesAsync();
        }
    }
}

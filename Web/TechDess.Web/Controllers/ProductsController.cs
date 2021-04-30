namespace TechDess.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TechDess.Services.Data.Cloudinary;
    using TechDess.Services.Data.Products;
    using TechDess.Services.Data.ProductTypes;
    using TechDess.Web.ViewModels.Products;
    using TechDess.Web.ViewModels.ProductTypes;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IProductTypesService productTypesService;
        private readonly ICloudinaryService cloudinaryService;

        public ProductsController(IProductsService productsService, IProductTypesService productTypesService, ICloudinaryService cloudinaryService)
        {
            this.productsService = productsService;
            this.productTypesService = productTypesService;
            this.cloudinaryService = cloudinaryService;
        }

        public IActionResult Create()
        {
            var productTypes = this.productTypesService.GetAll<ProductTypeDropDownViewModel>();
            var viewModel = new ProductCreateInputModel()
            {
                ProductTypes = productTypes,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var image = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Name);

            var productId = await this.productsService.CreateAsync(input, image);
            this.TempData["InfoMessage"] = "Product created!";
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input, int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 8;
            var viewModel = new ProductListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                Count = this.productsService.GetCount(),
                Products = this.productsService.GetByProductTypes<ProductInListViewModel>(input.Id, page, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var product = this.productsService.GetById<SingleProductViewModel>(id);
            return this.View(product);
        }

        public IActionResult Increasing(SearchListInputModel input, int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 8;
            var viewModel = new ProductListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                Count = this.productsService.GetCount(),
                Products = this.productsService.GetAllIncreasing<ProductInListViewModel>(input.Id, page, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult Decreasing(SearchListInputModel input, int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 8;
            var viewModel = new ProductListViewModel()
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = page,
                Count = this.productsService.GetCount(),
                Products = this.productsService.GetAllDecreasing<ProductInListViewModel>(input.Id, page, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await this.productsService.DeleteAsync(id);

            return this.RedirectToAction("Index", "Home");
        }
    }
}

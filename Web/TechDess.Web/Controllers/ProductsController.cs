namespace TechDess.Web.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Services.Data.Cloudinary;
    using TechDess.Services.Data.Orders;
    using TechDess.Services.Data.Products;
    using TechDess.Services.Data.ProductTypes;
    using TechDess.Web.ViewModels.Orders;
    using TechDess.Web.ViewModels.Products;
    using TechDess.Web.ViewModels.ProductTypes;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IProductTypesService productTypesService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IOrdersService ordersService;

        public ProductsController(IProductsService productsService, IProductTypesService productTypesService, ICloudinaryService cloudinaryService, IOrdersService ordersService)
        {
            this.productsService = productsService;
            this.productTypesService = productTypesService;
            this.cloudinaryService = cloudinaryService;
            this.ordersService = ordersService;
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

        public IActionResult SearchByTerm(ProductListViewModel input)
        {
            var viewModel = new ProductListViewModel()
            {
                Products = this.productsService.SearchByTerm<ProductInListViewModel>(input.SearchTerm),
                SearchTerm = input.SearchTerm,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await this.productsService.DeleteAsync(id);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var inputModel = this.productsService.GetById<CreateEditInputModel>(id);
            inputModel.ProductTypes = this.productTypesService.GetAll<ProductTypeDropDownViewModel>();
            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.ProductTypes = this.productTypesService.GetAll<ProductTypeDropDownViewModel>();
                return this.View(input);
            }

            await this.productsService.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var order = new CreateOrderModel()
            {
                UserId = userId,
                ProductId = input.ProductId,
                Quantity = input.Quantity,
            };
            order.StatusId = await this.ordersService.Create(order);
            return this.RedirectToAction("Cart", "Orders");
        }
    }
}

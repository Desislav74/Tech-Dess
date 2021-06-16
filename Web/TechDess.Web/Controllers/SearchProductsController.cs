namespace TechDess.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechDess.Services.Data.Characteristics;
    using TechDess.Services.Data.Products;
    using TechDess.Web.ViewModels.Products;
    using TechDess.Web.ViewModels.SearchProducts;

    public class SearchProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICharacteristicsService characteristicsService;

        public SearchProductsController(IProductsService productsService, ICharacteristicsService characteristicsService)
        {
            this.productsService = productsService;
            this.characteristicsService = characteristicsService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Characteristics = this.characteristicsService.GetAll<CharacteristicNameIdViewModel>(),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(ViewModels.SearchProducts.SearchListInputModel input)
        {
            var viewModel = new ListViewModel
            {
                Products = this.productsService
                    .GetByCharacteristics<ProductInListViewModel>(input.Characteristics),
            };

            return this.View(viewModel);
        }
    }
}

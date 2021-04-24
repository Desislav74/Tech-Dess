namespace TechDess.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using TechDess.Services.Data.ProductTypes;
    using TechDess.Web.ViewModels;
    using TechDess.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IProductTypesService productTypesService;

        public HomeController(IProductTypesService productTypesService)
        {
            this.productTypesService = productTypesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexProductTypesViewModel()
            {
                ProductTypes = this.productTypesService.GetAll<IndexPageProductTypeViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

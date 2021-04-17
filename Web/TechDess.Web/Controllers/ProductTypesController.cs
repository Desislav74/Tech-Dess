namespace TechDess.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TechDess.Services.Data.ProductTypes;
    using TechDess.Web.ViewModels.ProductTypes;

    public class ProductTypesController : Controller
    {
        private readonly IProductTypesService productTypesService;

        public ProductTypesController(IProductTypesService productTypesService)
        {
            this.productTypesService = productTypesService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductTypeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                await this.productTypesService.CreateAsync(input);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}

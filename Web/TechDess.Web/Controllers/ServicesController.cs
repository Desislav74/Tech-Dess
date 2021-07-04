namespace TechDess.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : Controller
    {
        public IActionResult ChooseDevice()
        {
            return this.View();
        }

        public IActionResult LoyalOffers()
        {
            return this.View();
        }

        public IActionResult Warranty()
        {
            return this.View();
        }

        public IActionResult Installations()
        {
            return this.View();
        }

        public IActionResult Courier()
        {
            return this.View();
        }

        public IActionResult Return()
        {
            return this.View();
        }
    }
}

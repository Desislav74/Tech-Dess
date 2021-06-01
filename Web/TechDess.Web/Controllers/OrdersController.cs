using TechDess.Services.Data.Receipts;

namespace TechDess.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TechDess.Services.Data.Orders;
    using TechDess.Web.ViewModels.Orders;
    using TechDess.Web.ViewModels.Products;

    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly IReceiptsService receiptsService;

        public OrdersController(IOrdersService ordersService, IReceiptsService receiptsService)
        {
            this.ordersService = ordersService;
            this.receiptsService = receiptsService;
        }

        public IActionResult Cart()
        {
            var viewModel = new ListOrderCartViewModel()
            {
                OrderCartViewModels = this.ordersService.GetAll<OrderCartViewModel>()
                        .Where(x => x.StatusName == "Active" 
                                    && x.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Increase(int id)
        {
            bool result = await this.ordersService.IncreaseQuantity(id);

            if (result)
            {
                return this.RedirectToAction(nameof(this.Cart));
            }
            else
            {
                return this.Forbid();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Reduce(int id)
        {
            bool result = await this.ordersService.ReduceQuantity(id);

            if (result)
            {
                return this.RedirectToAction(nameof(this.Cart));
            }
            else
            {
                return this.Forbid();
            }
        }

        [HttpPost]

        public async Task<IActionResult> Complete()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var receiptId = await this.receiptsService.CreateReceipt(userId);
            return this.Redirect($"/Receipts/Detail/{receiptId}");
        }
    }
}

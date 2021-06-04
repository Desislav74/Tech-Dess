using System.Collections.Generic;

namespace TechDess.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Services.Data.Orders;
    using TechDess.Services.Data.Receipts;
    using TechDess.Web.ViewModels.Receipts;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptsService receiptsService;
        private readonly IOrdersService ordersService;

        public ReceiptsController(IReceiptsService receiptsService, IOrdersService ordersService)
        {
            this.receiptsService = receiptsService;
            this.ordersService = ordersService;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var receipts = new ListReceiptProfileViewModel()
            {
                ReceiptProfileViewModels = this.receiptsService
                    .GetAllByRecipientId<ReceiptProfileViewModel>(userId).ToList(),
            };
            return this.View(receipts);
        }

        [HttpGet]
        public IActionResult Detail(int id, ReceiptDetailsViewModel input)
        {
            string userEmail = this.User.FindFirst(ClaimTypes.Email).Value;
            var viewModel = new ReceiptDetailsViewModel()
           {
               Id = input.Id,
               CreatedOn = DateTime.UtcNow,
               Recipient = userEmail,
               Orders = this.ordersService.GetAll<ReceiptDetailsOrderViewModel>()
                    .Where(x => x.Id == id)
                    .ToList(),
           };
            return this.View(viewModel);
        }
    }
}

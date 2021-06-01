using TechDess.Web.ViewModels.Orders;
using TechDess.Web.ViewModels.Receipts;

namespace TechDess.Services.Data.Receipts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Services.Data.Orders;
    using TechDess.Services.Mapping;

    public class ReceiptsService : IReceiptsService
    {
        private readonly IDeletableEntityRepository<Receipt> receiptsRepository;
        private readonly IOrdersService ordersService;

        public ReceiptsService(IDeletableEntityRepository<Receipt> receiptsRepository, IOrdersService ordersService)
        {
            this.receiptsRepository = receiptsRepository;
            this.ordersService = ordersService;
        }

        public async Task<int> CreateReceipt(string recipientId)
        {
            var receipt = new Receipt
            {
                UserId = recipientId,
            };

            await this.ordersService.SetOrdersToReceipt(receipt);

            foreach (var order in receipt.Orders)
            {
                await this.ordersService.CompleteOrder(order.Id);
            }

            await this.receiptsRepository.AddAsync(receipt);
            int result = await this.receiptsRepository.SaveChangesAsync();

            return receipt.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var orders = this.receiptsRepository.All()
                .OrderBy(x => x.CreatedOn).To<T>().ToList();
            return orders;
        }

        public IEnumerable<T> GetAllByRecipientId<T>(string receiptId)
        {
            var query = this.receiptsRepository.All().AsQueryable()
                .Where(x => x.UserId == receiptId)
                .OrderByDescending(x => x.CreatedOn)
                .To<T>().ToList();
            return query;
        }
    }
}

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
    using TechDess.Web.ViewModels.Orders;
    using TechDess.Web.ViewModels.Receipts;

    public class ReceiptsService : IReceiptsService
    {
        private readonly IDeletableEntityRepository<Receipt> receiptsRepository;
        private readonly IOrdersService ordersService;
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public ReceiptsService(IDeletableEntityRepository<Receipt> receiptsRepository, IOrdersService ordersService, IDeletableEntityRepository<Order> orderRepository)
        {
            this.receiptsRepository = receiptsRepository;
            this.ordersService = ordersService;
            this.orderRepository = orderRepository;
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
            var result = await this.receiptsRepository.SaveChangesAsync();

            return receipt.Id;
        }

        public IEnumerable<T> GetAll<T>(int id)
        {
          var orders = this.orderRepository.All()
              .Where(x => x.Receipt.Id == id)
                .To<T>().ToList();
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

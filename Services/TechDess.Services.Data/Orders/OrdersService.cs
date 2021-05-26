namespace TechDess.Services.Data.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using TechDess.Data.Common.Models;
    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;
    using TechDess.Web.ViewModels.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;
        private readonly IRepository<OrderStatus> orderStatusRepository;

        public OrdersService(IDeletableEntityRepository<Order> orderRepository, IRepository<OrderStatus> orderStatusRepository)
        {
            this.orderRepository = orderRepository;
            this.orderStatusRepository = orderStatusRepository;
        }

        public async Task<int> Create(CreateOrderModel orderModel)
        {
            var order = new Order()
            {
                ProductId = orderModel.ProductId,
                StatusId = orderModel.StatusId,
                Quantity = orderModel.Quantity,
                UserId = orderModel.UserId,
            };
            order.Status = this.orderStatusRepository.All()
                .FirstOrDefault(x => x.Name == "Active");
            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();
            return order.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var orders = this.orderRepository.All()
                .OrderBy(x => x.CreatedOn).To<T>().ToList();
            return orders;
        }

        public async Task<bool> IncreaseQuantity(int orderId)
        {
            var order = this.orderRepository.All()
                .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            order.Quantity++;

            this.orderRepository.Update(order);
            int result = await this.orderRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ReduceQuantity(int orderId)
        {
            var order = this.orderRepository.All()
                .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (order.Quantity > 0)
            {
                order.Quantity--;
            }

            this.orderRepository.Update(order);
            int result = await this.orderRepository.SaveChangesAsync();

            return result > 0;
        }
    }
}

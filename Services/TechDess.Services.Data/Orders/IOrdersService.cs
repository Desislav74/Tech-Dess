namespace TechDess.Services.Data.Orders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TechDess.Data.Models;
    using TechDess.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        Task<int> Create(CreateOrderModel orderModel);

        IEnumerable<T> GetAll<T>();

        Task<bool> IncreaseQuantity(int orderId);

        Task<bool> ReduceQuantity(int orderId);

        Task<bool> CompleteOrder(int orderId);

        Task SetOrdersToReceipt(Receipt receipt);
    }
}

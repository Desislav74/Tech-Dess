using System.Collections.Generic;

namespace TechDess.Services.Data.Orders
{
    using System.Threading.Tasks;

    using TechDess.Web.ViewModels.Orders;

    public interface IOrdersService
    {
        Task<int> Create(CreateOrderModel orderModel);

        IEnumerable<T> GetAll<T>();

        Task<bool> IncreaseQuantity(int orderId);

        Task<bool> ReduceQuantity(int orderId);
    }
}

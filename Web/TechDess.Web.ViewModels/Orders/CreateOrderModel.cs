namespace TechDess.Web.ViewModels.Orders
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class CreateOrderModel : IMapFrom<Order>
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int StatusId { get; set; }

        public OrderStatus Status { get; set; }
    }
}
namespace TechDess.Web.ViewModels.Orders
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class OrderInputModel : IMapFrom<Order>
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

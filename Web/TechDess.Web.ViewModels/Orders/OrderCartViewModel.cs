namespace TechDess.Web.ViewModels.Orders
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class OrderCartViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string StatusName { get; set; }

        public string UserId { get; set; }
    }
}

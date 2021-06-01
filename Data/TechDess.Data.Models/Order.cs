namespace TechDess.Data.Models
{
    using TechDess.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int StatusId { get; set; }

        public virtual OrderStatus Status { get; set; }
    }
}

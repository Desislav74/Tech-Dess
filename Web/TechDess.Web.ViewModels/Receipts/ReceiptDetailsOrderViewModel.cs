namespace TechDess.Web.ViewModels.Receipts
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ReceiptDetailsOrderViewModel : IMapFrom<Order>, IMapTo<Order>, IMapTo<Receipt>, IMapFrom<Receipt>
    {
        public int Id { get; set; }

        //public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}

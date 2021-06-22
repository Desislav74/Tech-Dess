namespace TechDess.Web.ViewModels.Receipts
{
    using AutoMapper;
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ReceiptDetailsOrderViewModel : IMapFrom<Order>, IMapFrom<Receipt>
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}

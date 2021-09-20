namespace TechDess.Web.ViewModels.Receipts
{
    using System;
    using System.Linq;

    using AutoMapper;
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ReceiptProfileViewModel : IMapFrom<Receipt>, IMapTo<Receipt>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Total { get; set; }

        public int Products { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Receipt, ReceiptProfileViewModel>()
                .ForMember(
                    destination => destination.Total,
                    opts => opts.MapFrom(origin => origin.Orders.Sum(x => x.Product.Price * x.Quantity)))
                .ForMember(
                    destination => destination.Products,
                    opts => opts.MapFrom(origin => origin.Orders.Sum(x => x.Quantity)));
        }
    }
}

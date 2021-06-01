namespace TechDess.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class OrderInputModel : IMapFrom<Order>
    {
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}

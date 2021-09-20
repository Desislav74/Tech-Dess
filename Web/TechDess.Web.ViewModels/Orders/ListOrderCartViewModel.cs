namespace TechDess.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class ListOrderCartViewModel
    {
        public IEnumerable<OrderCartViewModel> OrderCartViewModels { get; set; }
    }
}

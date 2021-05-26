using System.Collections.Generic;

namespace TechDess.Web.ViewModels.Orders
{
    public class ListOrderCartViewModel
    {
        public IEnumerable<OrderCartViewModel> OrderCartViewModels { get; set; }
    }
}

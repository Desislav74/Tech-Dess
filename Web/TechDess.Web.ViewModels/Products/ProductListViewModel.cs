using System.Collections.Generic;

namespace TechDess.Web.ViewModels.Products
{
    public class ProductListViewModel : PagingViewModel
    {
        public IEnumerable<ProductInListViewModel> Products { get; set; }
    }
}

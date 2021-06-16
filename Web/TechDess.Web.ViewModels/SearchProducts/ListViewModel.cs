namespace TechDess.Web.ViewModels.SearchProducts
{
    using System.Collections.Generic;

    using TechDess.Data.Models;
    using TechDess.Services.Mapping;
    using TechDess.Web.ViewModels.Products;

    public class ListViewModel
    {
        public IEnumerable<ProductInListViewModel> Products { get; set; }
    }
}

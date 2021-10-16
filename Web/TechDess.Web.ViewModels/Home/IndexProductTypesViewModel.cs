namespace TechDess.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexProductTypesViewModel
    {
        public string SearchTerm { get; set; }

        public IEnumerable<IndexPageProductTypeViewModel> ProductTypes { get; set; }
    }
}

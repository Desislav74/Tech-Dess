﻿namespace TechDess.Web.ViewModels.Products
{
    using System.Collections.Generic;

    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ProductListViewModel : PagingViewModel
    {
        public IEnumerable<ProductInListViewModel> Products { get; set; }
    }
}

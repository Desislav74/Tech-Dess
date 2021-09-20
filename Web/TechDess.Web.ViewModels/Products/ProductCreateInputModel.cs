namespace TechDess.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;
    using TechDess.Web.ViewModels.ProductTypes;

    public class ProductCreateInputModel : IMapFrom<Product>, IMapTo<Product>
    {
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public ProductType Type { get; set; }

        public IEnumerable<ProductTypeDropDownViewModel> ProductTypes { get; set; }

        public IEnumerable<ProductCharacteristicInputModel> Characteristics { get; set; }
    }
}

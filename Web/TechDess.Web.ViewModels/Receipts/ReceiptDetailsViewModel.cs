namespace TechDess.Web.ViewModels.Receipts
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class ReceiptDetailsViewModel : IMapFrom<Receipt>, IMapTo<Receipt>
    {
        public int Id { get; set; }

        public string Recipient { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<ReceiptDetailsOrderViewModel> Orders { get; set; }
    }
}

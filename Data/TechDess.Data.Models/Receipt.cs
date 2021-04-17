namespace TechDess.Data.Models
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using TechDess.Data.Common.Models;

    public class Receipt : BaseDeletableModel<int>
    {
        public Receipt()
        {
            this.Orders = new HashSet<Order>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

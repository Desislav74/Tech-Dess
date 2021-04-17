namespace TechDess.Data.Models
{
    using TechDess.Data.Common.Models;

    public class OrderStatus : BaseModel<int>
    {
        public string Name { get; set; }
    }
}

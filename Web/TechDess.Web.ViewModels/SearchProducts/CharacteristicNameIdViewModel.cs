namespace TechDess.Web.ViewModels.SearchProducts
{
    using TechDess.Data.Models;
    using TechDess.Services.Mapping;

    public class CharacteristicNameIdViewModel : IMapFrom<Characteristic>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

namespace TechDess.Services.Data.Characteristics
{
    using System.Collections.Generic;

    public interface ICharacteristicsService
    {
        IEnumerable<T> GetAll<T>();
    }
}

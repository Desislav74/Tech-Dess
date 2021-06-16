using System.Collections.Generic;
using System.Linq;
using TechDess.Services.Mapping;

namespace TechDess.Services.Data.Characteristics
{
    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;

    public class CharacteristicsService : ICharacteristicsService
    {
        private readonly IDeletableEntityRepository<Characteristic> characteristicRepository;

        public CharacteristicsService(IDeletableEntityRepository<Characteristic> characteristicRepository)
        {
            this.characteristicRepository = characteristicRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.characteristicRepository.All()
                .To<T>().ToList();
        }
    }
}

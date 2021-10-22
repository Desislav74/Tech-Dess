namespace TechDess.Services.Data.Votes
{
    using System.Linq;
    using System.Threading.Tasks;

    using TechDess.Data.Common.Repositories;
    using TechDess.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int productId)
        {
            return this.votesRepository.All()
                .Where(x => x.ProductId == productId)
                .Average(x => x.Value);
        }

        public async Task SetVoteAsync(int productId, string userId, byte value, bool isProductRatedByUser)
        {
            var vote = new Vote
                {
                    ProductId = productId,
                    UserId = userId,
                    IsProductRatedByUser = true,
                };
            await this.votesRepository.AddAsync(vote);
            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}

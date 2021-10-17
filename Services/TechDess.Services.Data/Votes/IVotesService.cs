namespace TechDess.Services.Data.Votes
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        double GetAverageVotes(int productId);

        Task SetVoteAsync(int productId, string userId, byte value);
    }
}

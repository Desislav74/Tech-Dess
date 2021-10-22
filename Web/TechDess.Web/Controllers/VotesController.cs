using System.Linq;
using TechDess.Data.Models;

namespace TechDess.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechDess.Data.Common.Repositories;
    using TechDess.Services.Data.Votes;
    using TechDess.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVotesService votesService;
        private readonly IRepository<Vote> votesRepository;

        public VotesController(IVotesService votesService, IRepository<Vote> votesRepository)
        {
            this.votesService = votesService;
            this.votesRepository = votesRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.ProductId == input.ProductId && x.UserId == userId);
            if (vote == null)
            {
                await this.votesService.SetVoteAsync(input.ProductId, userId, input.Value, input.IsProductRatedByUser);
                var averageVotes = this.votesService.GetAverageVotes(input.ProductId);
                return new PostVoteResponseModel { AverageVote = averageVotes };
            }
            else
            {
                return this.RedirectToAction("Index", "Home");
            }
        }
    }
}

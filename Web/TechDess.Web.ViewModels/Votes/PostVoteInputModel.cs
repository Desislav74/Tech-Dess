namespace TechDess.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class PostVoteInputModel
    {
        public int ProductId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }

        public string UserId { get; set; }

        public bool IsProductRatedByUser { get; set; }
    }
}

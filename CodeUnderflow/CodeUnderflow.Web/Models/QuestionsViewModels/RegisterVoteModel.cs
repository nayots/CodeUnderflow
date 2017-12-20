using System.ComponentModel.DataAnnotations;

namespace CodeUnderflow.Web.Models.QuestionsViewModels
{
    public class RegisterVoteModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? QuestionId { get; set; }

        public bool IsUpvote { get; set; }
    }
}
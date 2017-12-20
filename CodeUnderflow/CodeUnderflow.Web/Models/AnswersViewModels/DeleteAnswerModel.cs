using System.ComponentModel.DataAnnotations;

namespace CodeUnderflow.Web.Models.AnswersViewModels
{
    public class DeleteAnswerModel
    {
        [Required]
        public int? QuestionId { get; set; }

        [Required]
        public int? AnswerId { get; set; }
    }
}
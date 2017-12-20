using System.ComponentModel.DataAnnotations;

namespace CodeUnderflow.Web.Models.AnswersViewModels
{
    public class EditAnswerModel
    {
        [Required]
        public int? AnswerId { get; set; }

        [Required]
        public int? QuestionId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(300)]
        public string Content { get; set; }
    }
}
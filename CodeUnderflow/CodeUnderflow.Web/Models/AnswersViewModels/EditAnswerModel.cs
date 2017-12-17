using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

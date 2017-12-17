using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

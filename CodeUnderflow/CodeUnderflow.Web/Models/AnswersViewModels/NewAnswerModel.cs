using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Web.Models.AnswersViewModels
{
    public class NewAnswerModel
    {
        public int? QuestionId { get; set; }

        [Required]
        [MaxLength(300)]
        public string Content { get; set; }
    }
}

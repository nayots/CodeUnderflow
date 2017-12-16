using CodeUnderflow.Common.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Web.Models.QuestionsViewModels
{
    public class NewQuestionModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(3000)]
        public string Content { get; set; }

        [MaxLength(50)]
        [Tags(ErrorMessage = "At least one tag is required to submit a question")]
        public string Tags { get; set; }
    }
}
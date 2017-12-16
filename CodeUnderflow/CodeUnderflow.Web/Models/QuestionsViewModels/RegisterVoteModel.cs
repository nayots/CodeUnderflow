using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

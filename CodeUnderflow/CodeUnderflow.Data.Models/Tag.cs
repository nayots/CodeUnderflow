using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeUnderflow.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        public ICollection<QuestionTag> Questions { get; set; } = new List<QuestionTag>();
    }
}
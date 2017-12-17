using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeUnderflow.Data.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public ICollection<QuestionTag> Tags { get; set; } = new List<QuestionTag>();

        public ICollection<Vote> Votes { get; set; } = new List<Vote>();

        public bool IsArchived { get; set; }

        public DateTime PostDate { get; set; }

        public DateTime? EditDate { get; set; }
    }
}
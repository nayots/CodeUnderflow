using System;
using System.ComponentModel.DataAnnotations;

namespace CodeUnderflow.Data.Models
{
    public class Reply
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int AnswerId { get; set; }

        public Answer Answer { get; set; }

        public DateTime PostDate { get; set; }
    }
}
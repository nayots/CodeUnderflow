using System;
using System.Collections.Generic;

namespace CodeUnderflow.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public string Content { get; set; }

        public bool IsBestAnswer { get; set; }

        public DateTime PostDate { get; set; }

        public int Votes { get; set; }
    }
}
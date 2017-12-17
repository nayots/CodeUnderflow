using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Data.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public bool IsUpvote { get; set; }
    }
}

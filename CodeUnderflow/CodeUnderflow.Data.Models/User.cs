using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CodeUnderflow.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();

        public int Reputation { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool IsBanned { get; set; }

        public bool IsDeleted { get; set; }

        public string PictureUrl { get; set; }
    }
}
using CodeUnderflow.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeUnderflow.Web.Data
{
    public class CodeUnderflowDbContext : IdentityDbContext<User>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public CodeUnderflowDbContext(DbContextOptions<CodeUnderflowDbContext> options)
            : base(options)
        {
            //this.Database.Migrate();
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.Questions)
                .WithOne(q => q.Author)
                .HasForeignKey(q => q.AuthorId);

            builder.Entity<User>()
                .HasMany(u => u.Answers)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);

            builder.Entity<User>()
                .HasMany(u => u.Replies)
                .WithOne(r => r.Author)
                .HasForeignKey(r => r.AuthorId);

            builder.Entity<User>()
                .HasMany(u => u.Votes)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            builder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            builder.Entity<QuestionTag>()
                .HasKey(qt => new { qt.QuestionId, qt.TagId });

            builder.Entity<Question>()
                .HasMany(q => q.Tags)
                .WithOne(qt => qt.Question)
                .HasForeignKey(qt => qt.QuestionId);

            builder.Entity<Question>()
                .HasMany(q => q.Votes)
                .WithOne(v => v.Question)
                .HasForeignKey(v => v.QuestionId);

            builder.Entity<Tag>()
                .HasMany(t => t.Questions)
                .WithOne(qt => qt.Tag)
                .HasForeignKey(qt => qt.TagId);

            builder.Entity<Answer>()
                .HasMany(a => a.Replies)
                .WithOne(r => r.Answer)
                .HasForeignKey(r => r.AnswerId);
        }
    }
}
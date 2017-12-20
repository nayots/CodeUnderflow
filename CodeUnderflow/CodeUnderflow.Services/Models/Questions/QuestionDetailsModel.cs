using AutoMapper;
using CodeUnderflow.Common.AutoMapper;
using CodeUnderflow.Data.Models;
using CodeUnderflow.Services.Models.Answers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeUnderflow.Services.Models.Questions
{
    public class QuestionDetailsModel : IMapFrom<Question>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public IEnumerable<string> SimilarTags { get; set; }

        public string AuthorName { get; set; }

        public int Votes { get; set; }

        public DateTime PostDate { get; set; }

        public DateTime? EditDate { get; set; }

        public ICollection<AnswersDetailsModel> Answers { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionDetailsModel>()
                .ForMember(dest => dest.Tags, cfg => cfg.MapFrom(source => source.Tags.Select(t => t.Tag.Title)))
                .ForMember(dest => dest.AuthorName, cfg => cfg.MapFrom(source => source.Author.UserName))
                .ForMember(des => des.Votes, cfg => cfg.MapFrom(source => source.Votes.Count));
        }
    }
}
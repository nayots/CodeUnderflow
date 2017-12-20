using AutoMapper;
using CodeUnderflow.Common.AutoMapper;
using CodeUnderflow.Data.Models;
using System;

namespace CodeUnderflow.Services.Models.Answers
{
    public class AnswersDetailsModel : IMapFrom<Answer>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public bool IsBestAnswer { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Answer, AnswersDetailsModel>()
                .ForMember(dest => dest.AuthorName, cfg => cfg.MapFrom(source => source.Author.UserName));
        }
    }
}
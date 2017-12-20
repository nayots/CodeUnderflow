using AutoMapper;
using CodeUnderflow.Common.AutoMapper;
using CodeUnderflow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeUnderflow.Services.Models.Questions
{
    public class QuestionInfoModel : IMapFrom<Question>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AnswersCount { get; set; }

        public DateTime PostDate { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionInfoModel>()
                .ForMember(dest => dest.AnswersCount, cfg => cfg.MapFrom(source => source.Answers.Count))
                .ForMember(dest => dest.Tags, cfg => cfg.MapFrom(source => source.Tags.Select(t => t.Tag.Title)));
        }
    }
}
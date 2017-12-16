using CodeUnderflow.Common.AutoMapper;
using CodeUnderflow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CodeUnderflow.Services.Models.Questions
{
    public class QuestionDetailsModel : IMapFrom<Question>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string AuthorName { get; set; }

        public DateTime PostDate { get; set; }

        public DateTime? EditDate { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionDetailsModel>()
                .ForMember(dest => dest.Tags, cfg => cfg.MapFrom(source => source.Tags.Select(t => t.Tag.Title)))
                .ForMember(dest => dest.AuthorName, cfg => cfg.MapFrom(source => source.Author.UserName));
        }

        //TODO add other things later
    }
}

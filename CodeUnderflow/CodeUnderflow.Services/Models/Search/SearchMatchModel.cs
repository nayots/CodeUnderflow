using AutoMapper;
using CodeUnderflow.Common.AutoMapper;
using CodeUnderflow.Data.Models;

namespace CodeUnderflow.Services.Models.Search
{
    public class SearchMatchModel : IMapFrom<Question>, IHaveCustomMapping
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Question, SearchMatchModel>()
                .ForMember(dest => dest.Title, cfg => cfg.MapFrom(source => source.Title.Length > 30 ? source.Title.Substring(0, 28) + ".." : source.Title))
                .ForMember(dest => dest.Url, cfg => cfg.MapFrom(source => source.Id));
        }
    }
}
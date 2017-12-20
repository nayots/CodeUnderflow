using AutoMapper;
using CodeUnderflow.Common.AutoMapper;
using CodeUnderflow.Common.Validations;
using CodeUnderflow.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CodeUnderflow.Services.Models.Questions
{
    public class QuestionEditModel : IMapFrom<Question>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(3000)]
        public string Content { get; set; }

        [MaxLength(50)]
        [Tags(ErrorMessage = "At least one tag is required to submit a question")]
        public string Tags { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionEditModel>()
                .ForMember(dest => dest.Tags, cfg => cfg.MapFrom(source => string.Join(", ", source.Tags.Select(t => t.Tag.Title))));
        }
    }
}
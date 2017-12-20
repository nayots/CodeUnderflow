using AutoMapper;

namespace CodeUnderflow.Common.AutoMapper
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
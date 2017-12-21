using System.Collections.Generic;

namespace CodeUnderflow.Services.Contracts
{
    public interface ITagService
    {
        IEnumerable<string> GetSimilarTags(IEnumerable<string> tags, int count);
        IEnumerable<string> GetPopularTags(int countToTake);
    }
}
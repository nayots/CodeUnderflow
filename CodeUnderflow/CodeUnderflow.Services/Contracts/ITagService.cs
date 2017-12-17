using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Services.Contracts
{
    public interface ITagService
    {
        IEnumerable<string> GetSimilarTags(IEnumerable<string> tags, int count);
    }
}

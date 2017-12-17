using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Services.Contracts
{
    public interface IAnswersService
    {
        void Create(int questionId, string userId, string content, DateTime postDate);
    }
}

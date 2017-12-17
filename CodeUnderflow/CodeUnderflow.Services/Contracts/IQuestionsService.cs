using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeUnderflow.Services.Models.Questions;

namespace CodeUnderflow.Services.Contracts
{
    public interface IQuestionsService
    {
        int CreateNew(string title, string content, string tags, DateTime postDate, string userId);
        bool Exists(int questionId);
        QuestionDetailsModel GetDetails(int questionId);
        bool IsAuthor(int questionId, string userId);
        QuestionEditModel GetEditInfo(int questionId);
        void Update(int questionId, string title, string content, string tags, DateTime editDate);
        void Delete(int questionId);
        int RegisterVote(int questionId, string userId);
        bool UserHasStared(int questionId, string userId);
        IEnumerable<QuestionInfoModel> GetLatestQuestion();
    }
}
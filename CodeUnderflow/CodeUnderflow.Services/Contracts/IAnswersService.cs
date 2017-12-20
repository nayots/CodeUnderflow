using System;

namespace CodeUnderflow.Services.Contracts
{
    public interface IAnswersService
    {
        void Create(int questionId, string userId, string content, DateTime postDate);

        bool Exists(int answerId);

        bool UserCanEdit(int anwerId, string userId);

        void Delete(int answerId);

        string GetAnswerContent(int answerId);

        void Update(int answerId, string content);
    }
}
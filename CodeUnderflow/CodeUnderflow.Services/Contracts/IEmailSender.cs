using System.Threading.Tasks;

namespace CodeUnderflow.Services.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
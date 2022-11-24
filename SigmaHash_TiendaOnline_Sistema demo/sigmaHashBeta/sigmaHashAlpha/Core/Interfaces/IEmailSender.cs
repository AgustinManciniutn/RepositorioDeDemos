using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using sigmaHashAlpha.Infrastructure.Email;
using EmailModel = sigmaHashAlpha.Infrastructure.Email.EmailModel;

namespace sigmaHashAlpha.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmail(string address, string subject, string body, List<EmailAttachment>? emailAttachment = null);
        Task SendEmail(EmailModel emailModel);
    }
}

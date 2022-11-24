
using Mailjet.Client;
using sigmaHashAlpha.Core.Interfaces;

namespace sigmaHashAlpha.Infrastructure.Email
{
    public abstract class EmailSender : IEmailSender
    {

        public static MailjetClient CreateMailJetClient()
        {
            return new MailjetClient("edefa48810d141c5badab4f9eadadc7d", "979480cf4a2984dd86b55ecc08be2fa3");
        }

        protected abstract Task Send(EmailModel email);

        public async Task SendEmail(EmailModel emailmodel)
        {
            await Send(emailmodel);
        }

        public async Task SendEmail(string address, string subject, string body, List<EmailAttachment>? emailAttachment = null)
        {
            await Send(new EmailModel
            {
                Attachments = emailAttachment!,
                Body = body,
                EmailAddress = address,
                Subject = subject
            });
        }


    }
}

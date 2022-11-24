

using sigmaHashAlpha.Core.Interfaces;
using sigmaHashAlpha.Infrastructure.Email;
using sigmaHashAlpha.Infrastructure.Email.EmailProvider;
using System.Threading.Tasks.Dataflow;

namespace sigmaHashAlpha.Infrastructure.HosttedService
{
    public class EmailHostedService : IHostedService, IDisposable
    {
        private Task? _sendTask;
        private CancellationTokenSource? _cancellationToken;
        private readonly BufferBlock<EmailModel> _mailQueue;
        private readonly IEmailSender _mailSender;

        public EmailHostedService()
        {
            _mailSender = new MailJetProvider();
            _mailQueue = new BufferBlock<EmailModel>();
            _cancellationToken = new CancellationTokenSource();
        }

        /// <summary>
        /// Method send email - wakeup BufferBlock
        /// </summary>

        public async Task SendEmailAsync(EmailModel emailmodel) => await _mailQueue.SendAsync(emailmodel);
        public async Task SendJetMail(EmailModel emailmodel) => await _mailQueue.SendAsync(emailmodel);
        public void Dispose()
        {
            DestroyTask();
        }

        private void DestroyTask()
        {
            try
            {
                if(_cancellationToken != null)
                {
                    _cancellationToken.Cancel();
                    _cancellationToken = null;
                }
                Console.WriteLine("[EMAIL SERVICE] DESTROY SERVICE");
            }
            catch
            {

            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("[EMAIL SERVICE] START SERVICE");
            _sendTask = BackgroundSendEmailAsync(_cancellationToken!.Token);
            return Task.CompletedTask;
        }

        private async Task BackgroundSendEmailAsync(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                try
                {
                    var email = await _mailQueue.ReceiveAsync();
                    await _mailSender.SendEmail(email);
                }catch(OperationCanceledException)
                {
                    break;
                }
                catch(Exception ex)
                {
                    Console.Write($"[EMAIL SERVICE] Exception{ex.Message}");
                }
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            DestroyTask();
            await Task.WhenAny(_sendTask!, Task.Delay(Timeout.Infinite, cancellationToken));
        }
    }
}

using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sigmaHashAlpha.Controllers
{
    public class EmailTestController : Controller
    {
        public async Task<IActionResult> SendEmail()
        {

            MailjetClient client = new MailjetClient("edefa48810d141c5badab4f9eadadc7d", "979480cf4a2984dd86b55ecc08be2fa3")
            {
 
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = SendV31.Resource,
            }
               .Property(Send.Messages, new JArray {
                new JObject {
                 {"From", new JObject {
                  {"Email", "sigmahashnoreply@gobs.com.ar"},
                  {"Name", "sigmahash"}
                  }},
                 {"To", new JArray {
                  new JObject {
                   {"Email", "agustinmancini100@gmail.com"},
                   {"Name", "You"}
                   }
                  }},
                 {"TemplateID", 4335007 },
                 {"Subject", "My first Mailjet Email!"},
                 {"TextPart", "Greetings from Mailjet!"},
                 {"HTMLPart", "<h3>Dear passenger 1, welcome to <a href=\"https://www.mailjet.com/\">Mailjet</a>!</h3><br />May the delivery force be with you!"}
                 }
                   });
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
            return new EmptyResult();

        }
    }
}

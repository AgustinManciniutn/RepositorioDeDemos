using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using sigmaHashAlpha.Core.Interfaces;

namespace sigmaHashAlpha.Infrastructure.Email.EmailProvider
{
    public class MailJetProvider : EmailSender, IEmailSender
    {
        protected override async Task Send(EmailModel email)
        {
            try
            {
                {

                    //JArray jArray = new JArray();
                    //JArray attachments = new JArray();

                    //if (email.Attachments != null && email.Attachments.Count() > 0)
                    //{
                    //    email.Attachments.ToList().ForEach(attachment => attachments.Add(

                    //        new JObject
                    //        {
                    //            new JProperty("Content-Type",attachment.ContentType),
                    //            new JProperty("Filename",attachment.Name),
                    //            new JProperty("Content",Convert.ToBase64String(attachment.Data))
                    //        }));
                    //}
                    //jArray.Add(new JObject
                    //{
                    //    new JProperty("FromEmail","sigmahashnoreply@gobs.com.ar"), //Use email you register with mailjet
                    //    new JProperty("FromName", "sigma Hash Store"),
                    //    new JProperty("Recipients", new JArray
                    //    {
                    //        new JObject
                    //        {
                    //            new JProperty("Email", email.EmailAddress),
                    //            new JProperty("Name", email.EmailAddress),

                    //        }
                    //    }),
                    //    new JProperty("TemplateID", 4335007),
                    //    new JProperty("TemplateLanguage", true),
                    //    new JProperty("Subject", email.Subject),
                    //    new JProperty("Text-part", "LJASDF;KJLFADSJLK;FASDJKL;"),
                    //    new JProperty("Html-part", email.Body), // we use html format
                    //    new JProperty("Attachments", attachments)
                    //});

                    //JArray obj = new JArray() {
                    //    new JObject {
                    // {"From", new JObject {
                    //  {"Email", "sigmahashnoreply@gobs.com.ar"},
                    //  {"Name", "Mailjet Pilot"}
                    //  }},
                    // {"To", new JArray {
                    //  new JObject {
                    //   {"Email", "agustinmancini100@gmail.com"},
                    //   {"Name", "passenger 1"}
                    //   }
                    //  }},
                    // {"TemplateID", "4335007"},
                    // {"TemplateLanguage", true},
                    // {"Subject", "Your email flight plan!"}
                    // }
                    //};

                }


                var client = EmailSender.CreateMailJetClient();
                var request = new MailjetRequest
                {
                    Resource = SendV31.Resource,

                }
                .Property(Mailjet.Client.Resources.Send.Messages, new JArray {
                new JObject {
                    {"From", new JObject {
                            {"Email", "sigmahashnoreply@gobs.com.ar"},
                            {"Name", "sigmahash"}
                        }},
                    {"To", new JArray {
                        new JObject 
                            {
                                {"Email", email.EmailAddress},
                                {"Name", "You"}
                            }
                        }},
                    {"TemplateID", email.TemplateId },
                    {"TemplateLanguage", true},
                    {"Subject", email.Subject},
                    {"Variables", email.Variables ?? new JObject{} }
                    }
                });
                var response = await client.PostAsync(request);

                Console.WriteLine($"Send result {response.StatusCode} with message: {response.Content}");
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}

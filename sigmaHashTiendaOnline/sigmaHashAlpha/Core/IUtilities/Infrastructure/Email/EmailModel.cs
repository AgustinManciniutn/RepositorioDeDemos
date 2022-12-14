using Newtonsoft.Json.Linq;

namespace sigmaHashAlpha.Infrastructure.Email
{
    public class EmailModel
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty ;
        public IEnumerable<EmailAttachment>? Attachments { get; set; }

        public decimal? Amount { get; set; }

        public int? TemplateId { get; set; }
        public JObject? Variables { get; set; }
    }

    public class EmailAttachment
    {
        public string Name { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] Data = new byte[0];
    }
}

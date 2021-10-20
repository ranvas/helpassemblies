using Mzt.WCFEmailSender.MailService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.WCFEmailSender
{
    public class GeneralMail : IMailAgent
    {
        private MailServiceClient _client;
        List<string> _bcc;
        public List<string> Bcc { get => _bcc ?? (_bcc = new List<string>()); set => _bcc = value; }
        List<string> _to;
        public List<string> To { get => _to ?? (_to = new List<string>()); set => _to = value; }

        public GeneralMail()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "BasicHttpBinding_GeneralMail";
            binding.OpenTimeout = TimeSpan.FromMinutes(5);
            binding.SendTimeout = TimeSpan.FromMinutes(25);
            binding.MaxBufferSize = 65536000;
            binding.MaxReceivedMessageSize = 65536000;
            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas();
            binding.ReaderQuotas.MaxArrayLength = 65536000;
            binding.ReaderQuotas.MaxBytesPerRead = 65536000;
            var mailServiceAddress = string.Empty;
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["mailServiceAddress"]))
                mailServiceAddress = "http://mtdata1/mail-service/MailService.svc";
            //mailServiceAddress = "http://localhost:64506/MailService.svc";
            else
                mailServiceAddress = ConfigurationManager.AppSettings["mailServiceAddress"];
            var epAddress = new EndpointAddress(mailServiceAddress);
            _client = new MailServiceClient(binding, epAddress);
        }

        public async Task SendAsync(string to, string msg, string subject = "ошибка", Dictionary<string, byte[]> attachments = null)
        {
            var mailData = new MailData
            {
                ContentType = MailContentType.Html
            };
            await SendAsync(to, msg, mailData, subject, attachments);
        }

        public async Task SendAsync(string to, string viewName, Dictionary<string, ModelField> model, string subject = "ошибка", Dictionary<string, byte[]> attachments = null)
        {
            var mailData = new MailData
            {
                ContentType = MailContentType.ViewName,
                Model = model
            };
            await SendAsync(to, viewName, mailData, subject, attachments);
        }

        private async Task SendAsync(string to, string content, MailData mailData, string subject = "ошибка", Dictionary<string, byte[]> attachments = null)
        {
            mailData.Bcc = FixEmails(null, _bcc);
            mailData.Subject = subject;
            mailData.Attachments = attachments;
            mailData.Content = content;
            var recipients = FixEmails(to, To);
            if (string.IsNullOrEmpty(recipients))
                throw new Exception("no recipients");
            mailData.To = recipients;
            var result = await _client.SendAsync(mailData);
            if (result.Status == DeliveryStatus.Error)
                throw new Exception("Delivery error. ReqId:" + result.RequestId + " Message:" + result.Message);
        }

        private string FixEmails(string email, List<string> emails)
        {
            if (emails == null)
                return email;
            if (!string.IsNullOrEmpty(email) && !emails.Contains(email))
                emails.Add(email);
            email = string.Join(";", emails.Distinct());
            return email;
        }

    }
}

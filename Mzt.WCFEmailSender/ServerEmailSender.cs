using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.WCFEmailSender
{
    public class ServerEmailSender
    {
        public static void SendEmail(string host, string to, string cc, string bcc, string body, string subject, string fromAddress, string fromDisplay, string credentialUser, string credentialPassword, Dictionary<string, byte[]> bytes, bool async = false)
        {
            if (bytes != null && bytes.Count > 0)
            {
                var attachments = new List<Attachment>();
                foreach (var s in bytes)
                {
                    attachments.Add(new Attachment(new MemoryStream(s.Value), s.Key));
                }
                SendEmail(host, to, cc, bcc, body, subject, fromAddress, fromDisplay, credentialUser, credentialPassword, attachments);
            }
            else
            {
                SendEmail(host, to, cc, bcc, body, subject, fromAddress, fromDisplay, credentialUser, credentialPassword);
            }
        }

        public static void SendEmail(string host, string to, string cc, string bcc, string body, string subject, string fromAddress, string fromDisplay, string credentialUser, string credentialPassword, List<string> filenames, bool async = false)
        {
            if (filenames != null && filenames.Count > 0)
            {
                var attachments = new List<Attachment>();
                foreach (var s in filenames)
                {
                    attachments.Add(new Attachment(s));
                }
                SendEmail(host, to, cc, bcc, body, subject, fromAddress, fromDisplay, credentialUser, credentialPassword, attachments);
            }
            else
            {
                SendEmail(host, to, cc, bcc, body, subject, fromAddress, fromDisplay, credentialUser, credentialPassword);
            }
        }


        public static void SendEmail(string host, string to, string cc, string bcc, string body, string subject, string fromAddress, string fromDisplay, string credentialUser, string credentialPassword, List<Attachment> attachments = null, bool async = false)
        {
            if (string.IsNullOrEmpty(host))
                host = "192.168.201.145";
            try
            {
                MailMessage mail = new MailMessage();
                mail.Body = body;
                mail.IsBodyHtml = true;
                if (to.Length > 0)
                {
                    string[] emails1 = to.Replace(';', ',').Split(',');
                    foreach (var s in emails1)
                        mail.To.Add(new MailAddress(s.Trim()));
                }
                else
                    return;

                if (cc.Length > 0)
                {
                    string[] emails2 = cc.Replace(';', ',').Split(',');
                    foreach (var s in emails2)
                        mail.CC.Add(new MailAddress(s.Trim()));
                }

                if (bcc.Length > 0)
                {
                    string[] emails3 = bcc.Replace(';', ',').Split(',');
                    foreach (var s in emails3)
                        mail.Bcc.Add(new MailAddress(s.Trim()));
                }

                mail.From = new MailAddress(fromAddress, fromDisplay, Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;
                if (attachments != null)
                {
                    foreach (var att in attachments)
                    {
                        mail.Attachments.Add(att);
                    }
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential(credentialUser, credentialPassword);
                smtp.Host = host;
                if (async)
                    smtp.SendAsync(mail, string.Empty);
                else
                    smtp.Send(mail);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\nTo:" + to);
                sb.Append("\nbody:" + body);
                sb.Append("\nsubject:" + subject);
                sb.Append("\nfromAddress:" + fromAddress);
                sb.Append("\nfromDisplay:" + fromDisplay);
                sb.Append("\ncredentialUser:" + credentialUser);
                sb.Append("\ncredentialPasswordto:" + credentialPassword);
                sb.Append("\nHosting:" + host);
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

    }
}

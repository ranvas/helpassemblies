using Mzt.WCFEmailSender.MailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.WCFEmailSender
{
    public interface IMailAgent
    {
        Task SendAsync(string to, string msg, string subject = "ошибка", Dictionary<string, byte[]> attachments = null);
        Task SendAsync(string to, string viewName, Dictionary<string, ModelField> model, string subject = "ошибка", Dictionary<string, byte[]> attachments = null);

    }
}

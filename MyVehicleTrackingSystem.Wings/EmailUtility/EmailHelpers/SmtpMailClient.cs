using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailUtility.EmailHelpers
{
   public class SmtpMailClient : IMailClient
    {
        public void SendMail(string subject, string[] recipients, string body, string attachmentpath)
        {
            try
            {
                var client = new SmtpClient();
                MailMessage message = new MailMessage();
                foreach (string address in recipients)
                {
                    message.To.Add(address);
                }
                message.Subject = subject;
                message.Body = body;
                if (!string.IsNullOrWhiteSpace(attachmentpath))
                {
                    message.Attachments.Add(new Attachment(attachmentpath));
                }
                message.IsBodyHtml = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

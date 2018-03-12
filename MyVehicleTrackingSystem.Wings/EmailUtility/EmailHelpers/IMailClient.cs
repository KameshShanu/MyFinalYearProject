using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailUtility.EmailHelpers
{
    public interface IMailClient
    {
        void SendMail(string subject, string[] recipients, string body, string attachmentpath);
    }
}

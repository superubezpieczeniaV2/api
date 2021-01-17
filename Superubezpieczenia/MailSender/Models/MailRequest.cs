using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.MailSender.Models
{
    public class MailRequest
    {
        public string _ToEmail { get; set; }
        public string _Subject { get; set; }
        public string _Body { get; set; }

        public MailRequest(string ToEmail, string Subject, string Body)
        {
            _ToEmail = ToEmail;
            _Subject = Subject;
            _Body = Body;
        }
        public MailRequest()
        {

        }
    }
}

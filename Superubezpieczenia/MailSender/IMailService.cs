using Superubezpieczenia.MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.MailSender
{
    public interface IMailService
    {
        Task SendEmail(MailRequest mailRequest);
    }
}

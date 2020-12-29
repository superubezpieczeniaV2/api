using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Superubezpieczenia.MailSender.Models;
using Superubezpieczenia.MailSender.Setings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.MailSender
{
    public class MailService : IMailService
    {
        private readonly MailConfig _mailConfig;
        public MailService(IOptions<MailConfig> mailConfig)
        {
            _mailConfig = mailConfig.Value;
        }
        public async Task SendEmail(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailConfig.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest._ToEmail));
            email.Subject = mailRequest._Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest._Body;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_mailConfig.Host, _mailConfig.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailConfig.Mail, _mailConfig.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

            }
            

        }
    }
}

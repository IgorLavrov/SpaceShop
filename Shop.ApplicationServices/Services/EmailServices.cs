using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using Shop.Core.Dto.Email;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using System.Runtime.Intrinsics.X86;
using System.Security.Authentication;

namespace Shop.ApplicationServices.Services
{
    public class EmailServices:IEmailService
    {
        public readonly IConfiguration _config;
        public EmailServices(IConfiguration config)
        {
            _config = config;
        }

        public async void sendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailHost").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            //smtp.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
            //smtp.CheckCertificateRevocation = false;//rabotaet
            //smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

           
        }

    }
}

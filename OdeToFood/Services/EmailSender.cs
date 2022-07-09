using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class EmailSender : IEmailSender
    {
        public string fromMail { get; set; }
        public string fromPassword { get; set; }
        public SmtpClient mailClient { get; set; }

        public EmailSender()
        {
            fromMail = "kirolosniseem.devoperations@outlook.com";
            fromPassword = "KN@DevOperations";
            mailClient = new SmtpClient(host: "smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var msg = new MailMessage();
            msg.From = new MailAddress(fromMail);
            msg.To.Add(email);
            msg.Subject = subject;
            msg.Body = $"<html><body>{htmlMessage}</body></html>";
            msg.IsBodyHtml = true;
            mailClient.Send(msg);
        }
    }
}

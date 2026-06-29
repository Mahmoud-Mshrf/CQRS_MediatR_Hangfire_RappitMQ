using ApplicationLayer.Interfaces;
using DomainLayer.HelpersAndOptions;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementation
{
    public partial class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            var email = new MimeMessage();
            email.To.Add(MailboxAddress.Parse(message.To));
            email.Sender = MailboxAddress.Parse(_settings.From);
            email.From.Add(MailboxAddress.Parse(_settings.From));
            email.Subject = message.Subject;

            var builder = new BodyBuilder();

            if (message.IsHtml)
            {
                builder.HtmlBody = message.Body;
            }
            else
            {
                builder.TextBody = message.Body;
            }

            email.Body = builder.ToMessageBody();

            using var client = new SmtpClient();

            await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.Username, _settings.Password);
            await client.SendAsync(email);
            await client.DisconnectAsync(true);
        }
    }
}

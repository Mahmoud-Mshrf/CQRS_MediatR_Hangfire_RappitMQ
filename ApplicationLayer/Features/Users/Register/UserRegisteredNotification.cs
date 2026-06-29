using ApplicationLayer.Interfaces;
using DomainLayer.HelpersAndOptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Features.Users.Register
{
    public sealed record UserRegisteredNotification(string FullName,int Id,string Email) : INotification;

    public sealed class UserRegisteredNotifiactionHandler : INotificationHandler<UserRegisteredNotification>
    {
        private readonly IEmailService _emailService;
        private readonly IBackgroundJobScheduler _jobScheduler;

        public UserRegisteredNotifiactionHandler(IEmailService emailService, IBackgroundJobScheduler jobScheduler)
        {
            _emailService = emailService;
            _jobScheduler = jobScheduler;
        }

        public async Task Handle(UserRegisteredNotification notification, CancellationToken cancellationToken)
        {
            var emailMessage = new EmailMessage { To = notification.Email, IsHtml = true, Subject = "WelcomEmail"};
            var body = await File.ReadAllTextAsync("C:\\Users\\Mahmoud-PC\\source\\repos\\RecapApiProject\\RecapApiProject\\Helpers\\VerifyEmail.html");
            body = body.Replace("{{UserName}}", notification.FullName);
            body = body.Replace("{{VerificationCode}}", new Random(100000).Next(999999).ToString());
            emailMessage.Body = body;
            _jobScheduler.Enqueue<IEmailService>(x => x.SendEmailAsync(emailMessage));
        }
    }
}

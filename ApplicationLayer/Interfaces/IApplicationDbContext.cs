using DomainLayer.HelpersAndOptions;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationLayer.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage message);
    }
    public interface IBackgroundJobScheduler
    {
        void Enqueue<T>(Expression<Func<T, Task>> methodCall);
    }
}

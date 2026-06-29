using ApplicationLayer.Interfaces;
using Hangfire;
using System.Linq.Expressions;

namespace InfrastructureLayer.Implementation
{
    public class BackgroundJobScheduler : IBackgroundJobScheduler
    {
        public void Enqueue<T>(Expression<Func<T, Task>> methodCall)
        {
            BackgroundJob.Enqueue(methodCall);
        }
    }
}

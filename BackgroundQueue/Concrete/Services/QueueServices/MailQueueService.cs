using BackgroundQueue.Abstractions.Services.QueueServices;
using BackgroundQueue.Models;

namespace BackgroundQueue.Concrete.Services.QueueServices;

public sealed class MailQueueService : BackgroundQueueService<MailModel>, IMailQueueService
{
    public MailQueueService(IConfiguration configuration) : base(configuration)
    {
    }
}
using BackgroundQueue.Models;

namespace BackgroundQueue.Abstractions.Services.QueueServices;

public interface IMailQueueService : IBackgroundTaskQueueService<MailModel>
{
}
using BackgroundQueue.Models;

namespace BackgroundQueue.Abstractions.Services.QueueServices;

public interface IMailQueueService : IBackgroundQueueService<MailModel>
{
}
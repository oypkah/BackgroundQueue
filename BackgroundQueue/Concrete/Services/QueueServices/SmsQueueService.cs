using BackgroundQueue.Abstractions.Services.QueueServices;

namespace BackgroundQueue.Concrete.Services.QueueServices;

public class SmsQueueService : BackgroundQueueService<string>, ISmsQueueService
{
    public SmsQueueService(IConfiguration configuration) : base(configuration)
    {
    }
}
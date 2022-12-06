namespace BackgroundQueue.Abstractions.Services.QueueServices;

public interface IBackgroundTaskQueueService<TQueue>
{
    ValueTask AddQueue(TQueue queue);
    ValueTask<TQueue> DeQueue(CancellationToken cancellationToken = default);
}
namespace BackgroundQueue.Abstractions.Services.QueueServices;

public interface IBackgroundQueueService<TQueue>
{
    ValueTask AddQueue(TQueue queue);
    ValueTask<TQueue> DeQueue(CancellationToken cancellationToken = default);
}
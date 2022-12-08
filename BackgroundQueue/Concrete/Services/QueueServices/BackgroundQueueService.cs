using System.Threading.Channels;
using BackgroundQueue.Abstractions.Services.QueueServices;

namespace BackgroundQueue.Concrete.Services.QueueServices;

public class BackgroundQueueService<TQueue> : IBackgroundQueueService<TQueue>
{
    private readonly Channel<TQueue> _queue;

    public BackgroundQueueService(IConfiguration configuration)
    {
        int.TryParse(configuration["QueueCapacity"], out int capaticy);

        BoundedChannelOptions options = new(capaticy)
        {
            FullMode = BoundedChannelFullMode.Wait
        };

        _queue = Channel.CreateBounded<TQueue>(options);
    }
    
    public async ValueTask AddQueue(TQueue queue)
    {
        ArgumentNullException.ThrowIfNull(queue);
        await _queue.Writer.WriteAsync(queue);
    }

    public ValueTask<TQueue> DeQueue(CancellationToken cancellationToken = default)
        => _queue.Reader.ReadAsync(cancellationToken);
}
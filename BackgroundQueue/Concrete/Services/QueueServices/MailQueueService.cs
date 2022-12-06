using System.Threading.Channels;
using BackgroundQueue.Abstractions.Services.QueueServices;
using BackgroundQueue.Models;

namespace BackgroundQueue.Concrete.Services.QueueServices;

public sealed class MailQueueService : IMailQueueService
{
    private readonly Channel<MailModel> _queue;

    public MailQueueService(IConfiguration configuration)
    {
        int.TryParse(configuration["QueueCapacity"], out int capaticy);

        BoundedChannelOptions options = new(capaticy)
        {
            FullMode = BoundedChannelFullMode.Wait
        };

        _queue = Channel.CreateBounded<MailModel>(options);
    }

    public async ValueTask AddQueue(MailModel queue)
    {
        ArgumentNullException.ThrowIfNull(queue);

        await _queue.Writer.WriteAsync(queue);
    }

    public ValueTask<MailModel> DeQueue(CancellationToken cancellationToken = default)
    {
        return _queue.Reader.ReadAsync(cancellationToken);
    }
}
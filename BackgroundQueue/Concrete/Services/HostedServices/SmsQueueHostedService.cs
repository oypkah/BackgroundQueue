using BackgroundQueue.Abstractions.Services.QueueServices;

namespace BackgroundQueue.Concrete.Services.HostedServices;

public sealed class SmsQueueHostedService : BackgroundService
{
    private readonly ILogger<MailQueueHostedService> _logger;
    private readonly ISmsQueueService _smsQueueService;

    public SmsQueueHostedService(ILogger<MailQueueHostedService> logger, ISmsQueueService smsQueueService)
    {
        _logger = logger;
        _smsQueueService = smsQueueService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var phoneNumber = await _smsQueueService.DeQueue(stoppingToken);
            await SendSmsAsync(phoneNumber, stoppingToken);
        }
    }

    private async Task SendSmsAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000, cancellationToken);
        _logger.LogInformation($"SendSmsAsync: Sms was sent to {phoneNumber} as 'Hi, if you want to see projects similar to this, check out my Github profile: https://github.com/oypkah'");
    }
}
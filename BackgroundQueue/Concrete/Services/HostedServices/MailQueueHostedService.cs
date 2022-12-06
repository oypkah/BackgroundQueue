using BackgroundQueue.Abstractions.Services.QueueServices;

namespace BackgroundQueue.Concrete.Services.HostedServices;

public class MailQueueHostedService : BackgroundService
{
    private readonly ILogger<MailQueueHostedService> _logger;
    private readonly IMailQueueService _mailQueueService;

    public MailQueueHostedService(ILogger<MailQueueHostedService> logger, IMailQueueService mailQueueService)
    {
        _logger = logger;
        _mailQueueService = mailQueueService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var mailModel = await _mailQueueService.DeQueue(stoppingToken);
            // await Task.Delay(1000, stoppingToken);
            _logger.LogInformation($"ExecuteAsync: Sent mail to {mailModel.Email} as <h1>Welcome, <b>{mailModel.Name} {mailModel.Surname}</b></h1>");
        }
    }
}
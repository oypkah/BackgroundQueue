using BackgroundQueue.Abstractions.Services.QueueServices;
using BackgroundQueue.Models;

namespace BackgroundQueue.Concrete.Services.HostedServices;

public sealed class MailQueueHostedService : BackgroundService
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
            await SendMailAsync(mailModel, stoppingToken);
        }
    }

    private async Task SendMailAsync(MailModel mailModel, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000, cancellationToken);
        _logger.LogInformation($"SendMailAsync: Mail was sent to {mailModel.Email} as 'Hi <b>{mailModel.Name} {mailModel.Surname}</b>, <p>if you want to see projects similar to this, check out my <a href='https://github.com/oypkah'>Github</a> profile</p>'");
    }
}
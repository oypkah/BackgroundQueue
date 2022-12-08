using BackgroundQueue.Abstractions.Services.QueueServices;
using BackgroundQueue.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundQueue.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class MailQueueController : ControllerBase
{
    private readonly IMailQueueService _mailQueueService;

    public MailQueueController(IMailQueueService mailQueueService)
    {
        _mailQueueService = mailQueueService;
    }

    [HttpPost("add")]
    public IActionResult Add(MailModel mailModel)
    {
        _mailQueueService.AddQueue(mailModel);
        return Ok();
    }

    [HttpPost("add-range")]
    public IActionResult AddRange(IEnumerable<MailModel> mailModels)
    {
        foreach (var mailModel in mailModels)
            _mailQueueService.AddQueue(mailModel);

        return Ok();
    }
}
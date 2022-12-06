using BackgroundQueue.Abstractions.Services.QueueServices;
using BackgroundQueue.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundQueue.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MailQueueController : ControllerBase
{
    private readonly IMailQueueService _mailQueueService;

    public MailQueueController(IMailQueueService mailQueueService)
    {
        _mailQueueService = mailQueueService;
    }
    
    [HttpPost]
    public IActionResult Add(MailModel[] mailModels)
    {
        foreach (var mailModel in mailModels)
        {
            _mailQueueService.AddQueue(mailModel);
        }

        return Ok();
    }
}
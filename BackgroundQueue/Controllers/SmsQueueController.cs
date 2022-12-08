using BackgroundQueue.Abstractions.Services.QueueServices;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundQueue.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class SmsQueueController : ControllerBase
{
    private readonly ISmsQueueService _smsQueueService;

    public SmsQueueController(ISmsQueueService smsQueueService)
    {
        _smsQueueService = smsQueueService;
    }

    [HttpPost("add")]
    public IActionResult Add(string phoneNumber)
    {
        _smsQueueService.AddQueue(phoneNumber);
        return Ok();
    }

    [HttpPost("add-range")]
    public IActionResult AddRange(IEnumerable<string> phoneNumbers)
    {
        foreach (var phoneNumber in phoneNumbers)
            _smsQueueService.AddQueue(phoneNumber);

        return Ok();
    }
}
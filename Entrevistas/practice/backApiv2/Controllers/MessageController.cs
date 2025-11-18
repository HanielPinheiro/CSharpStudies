using backApiv2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

namespace backApiv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly QueueService _queueService;

        public MessagesController(IDistributedCache cache, QueueService queueService)
        {
            _cache = cache;
            _queueService = queueService;
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] string message)
        {
            _queueService.PublishMessageAsync("processing_queue", message);
            return Accepted();
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetCachedMessage(string key)
        {
            var cachedValue = await _cache.GetStringAsync(key);

            if (cachedValue != null)
            {
                return Ok(new { source = "cache", data = cachedValue });
            }

            return NotFound();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

namespace backApiv2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CachedController : ControllerBase
    {
      
        private readonly ILogger<CachedController> _logger;
        //private readonly IMemoryCache _memoryCache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public CachedController(ILogger<CachedController> logger, IConnectionMultiplexer connectionMultiplexer)
        {
            _logger = logger;
            _connectionMultiplexer = connectionMultiplexer;
        }

        [HttpPost("")]
        public async Task<IActionResult> SetAsync(string value, string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value, flags: CommandFlags.FireAndForget);
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAsync(string key)
        {
            string? value = await _connectionMultiplexer.GetDatabase().StringGetAsync(key);
            if (string.IsNullOrEmpty(value)) return NotFound();
            return Ok(value);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CacheAndCookies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CacheController : Controller
    {
        private readonly IMemoryCache _cache;

        public CacheController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Cache()
        {
            var time = _cache.GetOrCreate("time", e =>
            {
                e.SetSlidingExpiration(TimeSpan.FromSeconds(10));
                e.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                return DateTime.Now.Second;
            });
            return Ok(time);
        }


    }
}

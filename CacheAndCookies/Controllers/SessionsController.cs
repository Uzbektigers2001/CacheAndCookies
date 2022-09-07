using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using RestSharp;

namespace CacheAndCookies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : Controller
    {
       
        [HttpGet]
        public IActionResult Session()
        {
            int? cookie = HttpContext.Session.GetInt32(".request.count");

            if (cookie is not null or 0)
            {
                _ = (int)cookie++;
                HttpContext.Session.SetInt32(".request.count", (int)cookie);
            }
            else
                HttpContext.Session.SetInt32(".request.count", 1);

            return Ok(HttpContext.Session.GetInt32(".request.count"));
        }
    }
}

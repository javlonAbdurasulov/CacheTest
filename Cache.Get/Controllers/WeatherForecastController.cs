using ChacheTest.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using WebGrease;

namespace Cache.Get.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Chache _cache;

        public WeatherForecastController(Chache chache,ILogger<WeatherForecastController> logger)
        {
            _logger = logger; 
            _cache = chache;
        }
        [HttpGet]
        public IActionResult GetObj()
        {
            string key = "123";
            var res = _cache.GetFromCache(key);

            return Ok(res);

        }
        [HttpPost]
        public IActionResult PostObj()
        {
            string key = "123";
            var res = _cache.AddToCache(key,"salom");

            return Ok();

        }

        
    }
}
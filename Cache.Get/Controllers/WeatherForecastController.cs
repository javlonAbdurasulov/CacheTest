using ChacheTest.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebGrease;

namespace Cache.Get.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Chache _chache;

        public WeatherForecastController(IMemoryCache memoryCache,ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _chache =new Chache(memoryCache);
        }
        [HttpGet]
        public IActionResult GetObj()
        {
            string key = "123";
            //var res = _memoryCache.Get(key);
            var res = _chache.GetFromCache(key);
            return Ok(res);

            //User user = new User()
            //{
            //    Id = 1,
            //    Email = "abdurasulov@gamail.com",
            //    Name = "javlon"
            //};
            //User obj = _memoryCache.Get<User>(key);
            //return Ok(obj);
        }

        
    }
}
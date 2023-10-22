using ChacheTest.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace CacheTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
    

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Chache _distributedCache;
        public WeatherForecastController(Chache chache,ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _distributedCache = chache;
        }
        [HttpPost]
        public IActionResult Post(string s)
        {
            string key = "123";
            _distributedCache.AddToCache(key,s);
            
            
            //if (string.IsNullOrEmpty(cacheMember))
            //{
            //    cacheMember = "salom";
            //    _distributedCache.SetString(key, cacheMember);
            //    return Ok(cacheMember);
            //}

            return Ok("add");
        }
        [HttpGet]
        public IActionResult Gets()
        {
            string key = "123";
            var res = _distributedCache.GetFromCache(key);
            return Ok(res);
        }


        //[HttpPost("[action]")]
        //public IActionResult Set(string name)
        //{
        //    string key = "123";
        //    var opt = new MemoryCacheEntryOptions()
        //    {
        //        AbsoluteExpiration = DateTime.Now.AddSeconds(3),
        //        Size = 1024,
        //        //Priority = CacheItemPriority.Normal,
        //        SlidingExpiration = TimeSpan.FromSeconds(5)
        //    };
        //    _memoryCache.Set(key, name,opt);

        //    return Ok();
        //}
        //[HttpGet("[action]")]
        //public IActionResult Get()
        //{
        //    string key = "123";
        //    var res = _memoryCache.Get(key);
        //    return Ok(res);
        //}


        //[HttpGet]
        //public IActionResult GetObj()
        //{
        //    string key = "123";
        //    User user = new User()
        //    {
        //        Id = 1,
        //        Email = "abdurasulov@gamail.com",
        //        Name = "javlon"
        //    };
        //    User obj = _memoryCache.Get<User>(key);
        //    return Ok(obj);
        //}



        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
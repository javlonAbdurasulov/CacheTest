using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

namespace ChacheTest.Application
{
    public class Chache
    {
        private readonly IDatabase _distributedCache;
        public Chache()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
            _distributedCache = redis.GetDatabase();
        }
        public string AddToCache(string key, string value)
        {
            _distributedCache.StringSet(key,value);
            return "do";
        }

        public string GetFromCache(string key)
        {
            return _distributedCache.StringGet(key);
        }
    }
}

using Microsoft.Extensions.Caching.Memory;

namespace ChacheTest.Application
{
    public class Chache
    {
        private readonly IMemoryCache _cache;
        public Chache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public string AddToCache(string key, string value)
        {
            return _cache.Set(key,value);
        }

        public string GetFromCache(string key)
        {
            return _cache.Get(key) as string;
        }
    }
}

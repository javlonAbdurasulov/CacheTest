using Microsoft.Extensions.Caching.Memory;

namespace ChacheTest.Application
{
    public class Chache
    {
        private static IMemoryCache _cache;
        public Chache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public void AddToCache(string key, string value)
        {
            _cache.Set(key,value);
        }

        public string GetFromCache(string key)
        {
            return _cache.Get(key) as string;
        }
    }
}

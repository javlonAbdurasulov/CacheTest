using LazyCache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace ChacheTest.Application
{
    public class Chache
    {
        private readonly IAppCache _cache;
        public Chache(IAppCache appCache)
        {
            _cache = appCache;
        }
        public string AddToCache(string key, string value)
        {
            _cache.Add(key,value);
            return "do";
        }

        public string GetFromCache(string key)
        {
                _cache.TryGetValue(key, out string s);
            return s; 
        }
    }
}

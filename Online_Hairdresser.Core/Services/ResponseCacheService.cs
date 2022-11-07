using Microsoft.Extensions.Caching.Memory;
using Online_Hairdresser.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public ResponseCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public object Get(string cacheKey)
        {
            var response = _memoryCache.Get<object>(cacheKey);
            return response;
        }

        public void Set(string cacheKey, object response, TimeSpan expireTimeSeconds)
        {
            if (response == null) return;
            _memoryCache.Set(cacheKey, response, expireTimeSeconds);

        }
    }
}

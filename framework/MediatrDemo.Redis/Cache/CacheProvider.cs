using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MediatrDemo.Redis.Cache
{
    public class CacheProvider : ICacheProvider
    {

        private readonly IDistributedCache Cache;
        private readonly ILogger Log;


        public CacheProvider(IDistributedCache cache, ILogger<CacheProvider> log)
        {
            Cache = cache;
            Log = log;
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            var response = await Cache.GetStringAsync(key);
            Log.LogInformation($"Cache Log { DateTime.Now.ToShortDateString() } -- Key: { key } Reponse Count: { response?.Count().ToString() } ");
            return response == null ? null : JsonSerializer.Deserialize<T>(response);

        }

        public async Task RemoveAsync(string key)
        {
            await Cache.RemoveAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options) where T : class
        {
            var response = JsonSerializer.Serialize(value);
            await Cache.SetStringAsync(key, response, options);
        }
    }
}

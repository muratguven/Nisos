
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace Nisos.Redis.Cache
{
    public interface ICacheProvider
    {
        // Get from cache
        Task<T> GetAsync<T>(string key) where T : class;
        // Set cache
        Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options) where T : class;
        // Remove or clear cache
        Task RemoveAsync(string key);
    }
}

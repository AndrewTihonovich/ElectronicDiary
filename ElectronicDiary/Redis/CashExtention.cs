using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Redis
{
    public static class CashExtention
    {
        public static async Task SetCashItemAsync<T>(this IDistributedCache cache, string key, T data)
        {
            TimeSpan? absoluteExpireTime = null;
            TimeSpan? unusedExpireTime = null;

            var option = new DistributedCacheEntryOptions();

            option.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(5);
            option.SlidingExpiration = unusedExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(key, jsonData, option);
        }

        public static async Task<T> GetCashItemAsync<T>(this IDistributedCache cache, string key)
        {
            var jsonData = await cache.GetStringAsync(key);

            if (jsonData is null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}

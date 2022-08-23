using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using WebAPI__CodeFirst.Classes;

namespace WebAPI__CodeFirst.Redis
{
    public static class CacheExtensions
    {

        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordID,
            T data,
            TimeSpan? absoluteExpirationDate = null,
            TimeSpan? unusedExpireDate = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow =
                absoluteExpirationDate ?? TimeSpan.FromSeconds(60);

            options.SlidingExpiration = unusedExpireDate;

            var jsonData = JsonSerializer.Serialize(data);

            await cache.SetStringAsync(recordID, jsonData, options);
             
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache,string recordID)
        {
            var jsonData = await cache.GetStringAsync(recordID);

            if ( jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}


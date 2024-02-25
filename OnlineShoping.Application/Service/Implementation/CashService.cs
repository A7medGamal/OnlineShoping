using Microsoft.Extensions.Caching.Distributed;
using OnlineShoping.Application.Service.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShoping.Application.Service.Implementation
{
    public class CashService : ICashService
    {
        private readonly IDistributedCache _cache;
        public CashService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public T Get<T>(string key)
        {
            var value = _cache.GetString(key);
            if (value != null)
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        public T Set<T>(string key, T value)
        {
            var timeOut = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24),
                SlidingExpiration = TimeSpan.FromMinutes(60)
            };
            _cache.SetString(key, JsonSerializer.Serialize(value), timeOut);
            return value;
        }
        //private readonly IConnectionMultiplexer _connectionMultiplexer;

        //public CashService(IConnectionMultiplexer connectionMultiplexer)
        //{
        //    _connectionMultiplexer = connectionMultiplexer;
        //}

        //public async Task<string> getexchangerate(string key)
        //{
        //    var db =_connectionMultiplexer.GetDatabase();
        //    return await db.StringGetAsync(key);

        //}

        //public async Task savexchangerate(string key, string rate)
        //{
        //    var db = _connectionMultiplexer.GetDatabase();
        //     await db.StringSetAsync(key, rate);
        //}
        //-----------------------------------
        //private readonly IDatabase _redisDatabase;

        //public CashService(IConnectionMultiplexer redisConnectionMultiplexer)
        //{
        //    _redisDatabase = redisConnectionMultiplexer.GetDatabase();
        //}

        //public void SaveExchangeRate(string currencyCode, decimal exchangeRate, TimeSpan expirationTime)
        //{
        //    _redisDatabase.StringSet(currencyCode, exchangeRate.ToString(), expirationTime);
        //}

        //public decimal? GetExchangeRate(string currencyCode)
        //{
        //    var result = _redisDatabase.StringGet(currencyCode);

        //    if (result.HasValue && decimal.TryParse(result, out decimal exchangeRate))
        //    {
        //        return exchangeRate;
        //    }

        //    return null;
        //}

    }
}

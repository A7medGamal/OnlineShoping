using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.Service.Interface
{
    public interface ICashService
    {
        T Get<T>(string key);
        T Set<T>(string key, T value);
        //void SaveExchangeRate(string currencyCode, decimal exchangeRate, TimeSpan expirationTime);
        //decimal? GetExchangeRate(string currencyCode);


        //-----------------------------
        //Task<string> getexchangerate(string key);
        //Task savexchangerate(string key,string rate);
    }
}

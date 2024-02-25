using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Application.SD
{
    public class CurrencySettings
    {
        public string RedisHost { get; set; }
        public int RedisPort { get; set; }
        public int RedisExpirationMinutes { get; set; }
        public string BaseCurrency { get; set; }
        
    }
}

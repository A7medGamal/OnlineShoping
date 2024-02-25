using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using OnlineShoping.Application.DTO;
using OnlineShoping.Application.Service.Interface;

namespace OnlineShoping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ICashService _cashService;
        //private readonly IConfiguration _configuration;

        public ExchangeRateController(ICashService redisCacheService/*, IConfiguration configuration*/)
        {
            _cashService = redisCacheService;
            //_configuration = configuration;
        }
        [HttpPost]
        public IActionResult SaveExchangeRate([FromBody] CurrencyExchangeDto model)
        {
            _cashService.Set<CurrencyExchangeDto>(model.CurrencyCode, model);
            return Ok(model);

        }
        [HttpGet]
        public IActionResult GetExchangeRate([FromQuery] string currencyCode)
        {
            var data =_cashService.Get<CurrencyExchangeDto>(currencyCode);
            return Ok(data);
        }
        //[HttpPost("save-exchange-rate")]
        //public IActionResult SaveExchangeRate([FromBody] CurrencyExchangeDto model)
        //{
        //    // Validate model as needed

        //    // Calculate expiration time
        //    var expirationTime = TimeSpan.FromMinutes(_configuration.GetValue<int>("CurrencyExchange:RedisExpirationMinutes"));

        //    // Save to Redis
        //    _cashService.SaveExchangeRate(model.CurrencyCode, model.ExchangeRate, expirationTime);

        //    return Ok("Exchange rate saved successfully");
        //}

        //[HttpGet("get-exchange-rate")]
        //public IActionResult GetExchangeRate([FromQuery] string currencyCode)
        //{
        //    // Retrieve from Redis
        //    var exchangeRate = _cashService.GetExchangeRate(currencyCode);

        //    if (exchangeRate == null)
        //    {
        //        return NotFound("Exchange rate not found for the specified currency code");
        //    }

        //    return Ok(exchangeRate);
        //}


        //------------------------------------------

        //public Exchangerate(ICashService cashService)
        //{
        //    _cashService = cashService;
        //}


        //[HttpPost("save")]
        //public IActionResult SaveCurrencyExchange([FromBody] string currencyCode ,string exchangeRate)
        //{


        //    _cashService.savexchangerate(currencyCode, exchangeRate);

        //    return Ok();
        //}

        //[HttpGet("get")]
        //public IActionResult GetCurrencyExchange([FromQuery] string currencyCode)
        //{
        //    var cacheKey = currencyCode;
        //    var cacheValue = _cashService.getexchangerate(cacheKey);

        //    if (cacheValue == null)
        //    {
        //        return NotFound("Exchange rate not found for the given currency code.");
        //    }

        //    return Ok(cacheValue);
        //}
    }
}

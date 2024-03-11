using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RapidApiConsume.Models
{
    public class ExchangeRatesResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public List<Data> data { get; set; }



        //[JsonProperty("exchange_rates")]
        //public List<ApiBookingVM> ExchangeRates { get; set; }

        //[JsonProperty("base_currency_date")]
        //public DateTime BaseCurrencyDate { get; set; }

        //[JsonProperty("base_currency")]
        //public string BaseCurrency { get; set; }
    }
}

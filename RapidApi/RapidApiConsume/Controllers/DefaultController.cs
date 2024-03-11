using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class DefaultController : Controller
    {


        public async Task<IActionResult> Index()
        {




            ExchangeRatesResponse exchangeRatesResponse;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/currency/get-exchange-rates?base_currency=USD&languagecode=en-us"),
                Headers =
                {
                    { "X-RapidAPI-Key", "80338c2ca8mshc3accb867764c99p186b4bjsna154d032c334" },
                    { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                exchangeRatesResponse = JsonConvert.DeserializeObject<ExchangeRatesResponse>(body);
            }

            return View(exchangeRatesResponse);
        }

    }
}

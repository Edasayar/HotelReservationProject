using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {

          
            WeatherViewModel weatherViewModel = new WeatherViewModel();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/%C4%B0stanbul"),
                Headers =
    {
        { "X-RapidAPI-Key", "80338c2ca8mshc3accb867764c99p186b4bjsna154d032c334" },
        { "X-RapidAPI-Host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                weatherViewModel = JsonConvert.DeserializeObject<WeatherViewModel>(body);

            }

            return View(weatherViewModel);


           
        }
    }
}

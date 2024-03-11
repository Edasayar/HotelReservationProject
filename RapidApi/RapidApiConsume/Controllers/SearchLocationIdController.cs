using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchViewModel> bookingApiLocationSearchViewModels = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={cityName}"),
                    Headers =
    {
        { "X-RapidAPI-Key", "80338c2ca8mshc3accb867764c99p186b4bjsna154d032c334" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var rootObject = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel.Rootobject>(body);
                    return View(rootObject.data.ToList());
                }
            }
            else
            {
                List<BookingApiLocationSearchViewModel> bookingApiLocationSearchViewModels = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=%C4%B0stanbul"),
                    Headers =
    {
        { "X-RapidAPI-Key", "80338c2ca8mshc3accb867764c99p186b4bjsna154d032c334" },
        { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var rootObject = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel.Rootobject>(body);
                    return View(rootObject.data.ToList());
                }
            }
           
        }
    }
}

using HotelProject.WebUI.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class WorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5027/api/WorkLocation");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<WorkLocationListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddWorkLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(WorkLocationCreateDto workLocationCreateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(workLocationCreateDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5027/api/WorkLocation", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5027/api/WorkLocation/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5027/api/WorkLocation/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WorkLocationUpdateDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWorkLocation(WorkLocationUpdateDto workLocationUpdateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(workLocationUpdateDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5027/api/WorkLocation/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}

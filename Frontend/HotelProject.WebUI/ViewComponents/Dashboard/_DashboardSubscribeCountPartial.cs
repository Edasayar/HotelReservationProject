using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/edaisfollowing"),
                Headers =
    {
        { "X-RapidAPI-Key", "80338c2ca8mshc3accb867764c99p186b4bjsna154d032c334" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                InstagramFollowersListDto instagramFollowersListDto = JsonConvert.DeserializeObject<InstagramFollowersListDto>(body);
                ViewBag.v1=instagramFollowersListDto.followers;
                ViewBag.v2=instagramFollowersListDto.following;
                
               
            }

           
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=nike"),
                Headers =
    {
        { "X-RapidAPI-Key", "80338c2ca8mshc3accb867764c99p186b4bjsna154d032c334" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                TwitterFollowersListDto twitterFollowersListDto = JsonConvert.DeserializeObject<TwitterFollowersListDto>(body2);
                ViewBag.v3 = twitterFollowersListDto.data.user_info.followers_count;
                ViewBag.v4 = twitterFollowersListDto.data.user_info.friends_count;

            }

           
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Feda-sayar55%2F&include_skills=false"),
                Headers =
    {
        { "X-RapidAPI-Key", "80338c2ca8mshc3accb867764c99p186b4bjsna154d032c334" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                LinkedinFollowersListDto linkedinFollowersListDto = JsonConvert.DeserializeObject<LinkedinFollowersListDto>(body3);
                ViewBag.v5 = linkedinFollowersListDto.data.followers_count;
                
            }




            return View();
        }
    }
}

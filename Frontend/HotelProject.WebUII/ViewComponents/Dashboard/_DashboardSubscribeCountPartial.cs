using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-best-experience.p.rapidapi.com/profile?username=nike"),
                Headers =
                {
                    { "x-rapidapi-key", "35073ca388msh46ec5686230f108p17de34jsnee3267a0b62c" },
                    { "x-rapidapi-host", "instagram-best-experience.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.following = resultInstagramFollowersDtos.following_count;
                ViewBag.followers = resultInstagramFollowersDtos.follower_count;

            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter-followers.p.rapidapi.com/nike/profile"),
                Headers =
                {
                      { "x-rapidapi-key", "35073ca388msh46ec5686230f108p17de34jsnee3267a0b62c" },
                      { "x-rapidapi-host", "twitter-followers.p.rapidapi.com" },
                },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.friends = resultTwitterFollowersDto.friendsCount;
                ViewBag.followerst = resultTwitterFollowersDto.followersCount;

            }
            return View();

        }
    }
}
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.Models;

namespace NutritionTracker.Pages.Users.Service
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
       {
            HttpClient client = _clientFactory.CreateClient("local");

            var result = await client.PostAsJsonAsync("Auth/register", request);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            HttpClient client = _clientFactory.CreateClient("local");

            var result = await client.PostAsJsonAsync("Auth/login", request);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }
    }
}

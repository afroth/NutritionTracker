using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace NutritionTracker
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,"Admin")
            }, "test authentication type");

            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace NutritionTracker.Pages.Admin
{
    public partial class AdminPage : ComponentBase
    {
        private bool authorized = false;

        protected override async Task OnInitializedAsync()
        {
            string role = (await AuthStateProvider.GetAuthenticationStateAsync())
                .User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role.Contains("Admin"))
            {
                authorized = true;
            }
        }
    }
}

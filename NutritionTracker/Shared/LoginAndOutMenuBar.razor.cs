using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace NutritionTracker.Shared
{
    public partial class LoginAndOutMenuBar : ComponentBase
    {
        private async void Logout()
        {
            await LocalStorage.RemoveItemAsync("authToken");
            await AuthStateProvider.GetAuthenticationStateAsync();

            navManager.NavigateTo("/");
        }
    }
}

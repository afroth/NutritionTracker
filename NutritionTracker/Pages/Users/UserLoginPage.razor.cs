using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace NutritionTracker.Pages.Users
{
    public partial class UserLoginPage : ComponentBase
    {
        private UserLogin user = new UserLogin();

        private async void HandleLoginAsync()
        {
            await LocalStorage.SetItemAsync<bool>("isAuthenticated", true);
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
        }

    }// end class
}// end namespace

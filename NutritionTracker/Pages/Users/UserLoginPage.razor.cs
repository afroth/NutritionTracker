using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace NutritionTracker.Pages.Users
{
    public partial class UserLoginPage : ComponentBase
    {
        private UserLogin user = new UserLogin();

        private async void HandleLoginAsync()
        {
            var result = await AuthService.Login(user);

            if (result.Success)
            {
                await LocalStorage.SetItemAsync<string>("authToken", result.Data);
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
            }
            else
            {
                ToastService.ShowError(result.Message);
            }
           
        }

    }// end class
}// end namespace

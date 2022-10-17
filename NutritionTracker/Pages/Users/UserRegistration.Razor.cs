using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace NutritionTracker.Pages.Users
{
    public partial class UserRegistration : ComponentBase
    {
        private UserRegister user = new UserRegister();

        private async void HandleRegistration()
        {
            var result = await AuthService.Register(user);

            if (result.Success)
            {
                ToastService.ShowSuccess(result.Message);
                NavigationManager.NavigateTo("");
            }
            else
            {
                ToastService.ShowError(result.Message);
            }
        }
    }
}

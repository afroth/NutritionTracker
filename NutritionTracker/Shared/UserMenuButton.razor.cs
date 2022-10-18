using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace NutritionTracker.Shared
{
    public partial class UserMenuButton : ComponentBase
    {
        private bool showUserMenu = false;

        private string UserMenuCssClass => showUserMenu ? "show-menu" : null;
        //*******************************************************************************
        //
        private void ToggleUserMenu()
        {
            showUserMenu = !showUserMenu;
        }
        //*******************************************************************************
        //
        private async Task HideUserMenu()
        {
            await Task.Delay(200);
            showUserMenu = false;
        }

        //*******************************************************************************
        //
        private async void Logout()
        {
            await LocalStorage.RemoveItemAsync("authToken");
            await AuthStateProvider.GetAuthenticationStateAsync();

            navManager.NavigateTo("");
        }
    }// end class
}// end namespace

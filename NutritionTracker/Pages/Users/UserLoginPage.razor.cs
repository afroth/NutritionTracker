using System;
using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace NutritionTracker.Pages.Users
{
    public partial class UserLoginPage : ComponentBase
    {
        private bool isAuthenticated = false;
        private UserLogin user = new UserLogin();

        private void HandleLogin()
        {
            Console.WriteLine($"username: {user.Username}");
            Console.WriteLine($"password: {user.Password}");
            isAuthenticated = true;
        }

    }// end class
}// end namespace

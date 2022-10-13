using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.Models;

namespace NutritionTracker.Pages.Users
{
    public partial class UserRegistration : ComponentBase
    {
        private UserRegister user = new UserRegister();

        public void HandleRegistration()
        {
            NavigationManager.NavigateTo("login");

        }
    }
}

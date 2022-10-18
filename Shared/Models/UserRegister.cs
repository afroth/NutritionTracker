using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required,StringLength(16, ErrorMessage = "Your username is too long (16 characters max)")]
        public string Username { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Range(0, 1000, ErrorMessage = "Please choose a number between 0 and 1000")]
        public string StartUnitId { get; set; } = "1";

        [Range(typeof(bool), "true", "true", ErrorMessage = "check saying you read terms and conditions!")]
        public bool IsConfirmed { get; set; } = true;
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class User
    {

        [Key]
        public int Id { set; get; }
        public string Email { set; get; }
        public string Username { set; get; }
        public byte[] PasswordHash { set; get; }
        public byte[] PasswordSalt { set; get; }
        public bool IsConfirmed { set; get; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Role { get; set; } = "BasicUser";
    }
}

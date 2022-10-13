using System;
using MediatR;
using Shared.Models;

namespace NutritionTrackerServer.Users.Add
{
    public class UserAddCommand : IRequest<User>
    {
        public int Id { set; get; }
        public string Email { set; get; }
        public string Username { set; get; }
        public byte[] PasswordHash { set; get; }
        public byte[] PasswordSalt { set; get; }
        public bool IsConfirmed { set; get; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

}

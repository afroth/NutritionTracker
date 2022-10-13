using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NutritionTrackerServer.Data;
using NutritionTrackerServer.Models;

namespace NutritionTrackerServer.Users.Add
{
    public class UserAddHandler : IRequest<User>
    {
        private readonly IngredientDbContext _db;

        public UserAddHandler(IngredientDbContext db)
        {
            _db = db;
        }

        public async Task<User> Handle(UserAddCommand request, CancellationToken cancellationToken)
        {

            var user = new User
            {
                Id = request.Id,
                Email = request.Email,
                Username = request.Username,
                PasswordHash = request.PasswordHash,
                PasswordSalt = request.PasswordSalt,
                IsConfirmed = request.IsConfirmed,
                IsDeleted = request.IsDeleted,
                DateCreated = request.DateCreated
            };
            try
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return user;
        }
    }   
}

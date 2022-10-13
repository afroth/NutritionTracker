using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NutritionTrackerServer.Models;
using NutritionTrackerServer.Data;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MediatR;
using NutritionTrackerServer.Users.Add;

namespace NutritionTrackerServer.Users.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IngredientDbContext _dbContext;
        //private readonly IMediator _mediatr;
        public static User user = new User();

        //*******************************************************************************
        public AuthRepository(IngredientDbContext context)
        {
            _dbContext = context;
           // _mediatr = mediator;
        }

        //*******************************************************************************
        public Task<ServiceResponse<string>> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        //*******************************************************************************
        public  async Task<ServiceResponse<int>> Register(User user, string password)
        {

            if(await UserExists(user.Email))
            {
                return new ServiceResponse<int> { 
                    Success = false, 
                    Message = "User already exists." 
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);

            return new ServiceResponse<int> { 
                Data = user.Id, 
                Message = "Registration Successful" 
            };
        }

        //*******************************************************************************
        public async Task<bool> UserExists(string email)
        {
            if (await _dbContext.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower()))
            {
                return true;
            }
            return false;
        }

        //*******************************************************************************
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //*******************************************************************************
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                // create new computed hash value with login password and salt
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                // if resulting passwordHash is the same as stored passwordHash then correct password.
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}

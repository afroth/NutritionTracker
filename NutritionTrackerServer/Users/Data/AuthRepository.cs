using System;
using System.Linq;
using System.Threading.Tasks;
using NutritionTrackerServer.Data;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace NutritionTrackerServer.Users.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IngredientDbContext _dbContext;
        private readonly IConfiguration _configuration;

        //private readonly IMediator _mediatr;
        public static User user = new User();

        //*******************************************************************************
        public AuthRepository(IngredientDbContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _configuration = configuration;
            // _mediatr = mediator;
        }

        //*******************************************************************************
        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            // trys to find a existing email with the passed in email
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower().Equals(email.ToLower()));
            // checking if the username and password are equal. if either do not match return false
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                // false match on either password or username
                response.Success = false;
                response.Message = "Username or password not found!";
            }
            else
            {
                // both username and password are a match
                response.Data = CreateToken(user);
            }
            return response;
        }

        //*******************************************************************************
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {

            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse<int>{
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
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //*******************************************************************************
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt)) {
                // create new computed hash value with login password and salt
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                // if resulting passwordHash is the same as stored passwordHash then correct password.
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        //*******************************************************************************
        private string CreateToken(User user)
        {
            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };
           

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }// end class
}// end namespace

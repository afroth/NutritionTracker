using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NutritionTrackerServer.Users.Data;
using Shared.Models;

namespace NutritionTrackerServer.Users.Controller
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IAuthRepository _authRepo;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, IAuthRepository authRepo)
        {
            _authRepo = authRepo;
            _configuration = configuration;
        }

        //*******************************************************************************
        //POST PATH /Auth/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegister request)
        {
            var response = await _authRepo.Register(
                    new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        IsConfirmed = request.IsConfirmed
                    },
                    request.Password
                );

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //*******************************************************************************
        //POST PATH /Auth/login
        //[HttpPost("login")]
        //public async Task <ActionResult<string>> Login(UserRegister request) 
        //{

        //}

        //*******************************************************************************
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        ////*******************************************************************************
        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        ////*******************************************************************************
        //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512(user.PasswordSalt))
        //    {
        //        // create new computed hash value with login password and salt
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        // if resulting passwordHash is the same as stored passwordHash then correct password.
        //        return computedHash.SequenceEqual(passwordHash);
        //    }   
        //}

    }// end class
}// end namespace

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
    [Route("Auth")]
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
        [HttpPost("login")]
        public async Task <ActionResult<string>> Login(UserLogin request) 
        {
            var response = await _authRepo.Login( request.Email,request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }// end class
}// end namespace

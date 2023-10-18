﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DocStore.Core.DataTransferObjects;
using DocStore.Core.Entities;
using DocStore.Core.Interfaces;
using DocStore.Core.Requests;
using DocStore.Core.Responses;
using DocumentStore.Enums;
using DocumentStore.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DocStore.Server.Controllers
{
    // Implementation based largely on http://jasonwatmore.com/post/2018/06/26/aspnet-core-21-simple-api-for-authentication-registration-and-user-management#user-dto-cs
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, IOptions<AppSettings> settings)
        {
            _userService = userService;
            _settings = settings.Value;
        }

        private AppSettings _settings { get; }

        [AllowAnonymous]
        [HttpPost("v1/Authenticate")]
        public AuthenticateResponse Authenticate([FromBody] UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
            {
                var badResponse = new AuthenticateResponse();
                badResponse.Code = ResponseCode.BadRequest;
                badResponse.Message = "Username or password is incorrect";
                return badResponse;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.AuthKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            var okResponse = new AuthenticateResponse();
            okResponse.UserId = user.Id;
            okResponse.Username = user.UserName;
            okResponse.FirstName = user.FirstName;
            okResponse.LastName = user.LastName;
            okResponse.Token = tokenString;
            return okResponse;
        }

        [AllowAnonymous]
        [HttpPost("v1/RegisterUser")]
        public NewRecordResponse RegisterUser([FromBody] RegisterUserCommand command)
        {
            return _userService.RegisterUser(command);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ETCWebApi.Domain.Models;
using ETCWebApi.Domain.Persistence.Contexts;
using ETCWebApi.Domain.Security.Hashing;
using ETCWebApi.Domain.Security.Tokens;
using ETCWebApi.Domain.Services;
using ETCWebApi.Resources;
using ETCWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ETCWebApi.Controllers
{
    public class LoginController : Controller
    {
        //private readonly IConfiguration _config;
        //private readonly AppDbContext _db;
        //private readonly IPasswordHasher _passworHasher;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;

        public LoginController(IMapper mapper, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }


        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult Login([FromBody]string email, string password)
        //{
        //    IActionResult response = Unauthorized();
        //User user = AuthenticateUser(login);
        //var user = _db.Users.FindAsync(email, password);
        //if (user != null)
        //{
        //    var tokenString = GenerateJWTToken(user);
        //    response = Ok(new
        //    {
        //        token = tokenString,
        //        userDetails = user,
        //    });
        //}
        //return response;


        //User AuthenticateUser(User loginCredentials)
        //{
        //    try {             
        //        var user = _db.Users.SingleOrDefault(x => x.Email == loginCredentials.Email && _passworHasher.HashPassword(x.Password == (loginCredentials.Password));
        //        return user;
        //    } catch(Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //string GenerateJWTToken(User userInfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt: SecretKey"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
        //        new Claim("FullName", userInfo.FullName.ToString()),
        //        new Claim("role",userInfo.UserRole),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    };
        //        var token = new JwtSecurityToken(
        //        issuer: _config[""],
        //        audience: _config[""],
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: credentials
        //    );
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
        [Route("/api/login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var accessTokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(accessTokenResource);
        }

        [Route("/api/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authenticationService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var tokenResource = _mapper.Map<AccessToken, AccessTokenResource>(response.Token);
            return Ok(tokenResource);
        }

        
        [HttpPost]
        public IActionResult RevokeToken([FromBody] RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _authenticationService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MngBussinessLogicLayer.DTO.JWT;
using MngBussinessLogicLayer.Repository.Interface;
using MngDataAccessLayer.Data;
using MngDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace MngBussinessLogicLayer.Repository.Implementation
{
    public class AuthService : IAuth
    {
        private readonly CoachingDbContext _coachingDbContext;
        private readonly IConfiguration _configuration;
        public AuthService(CoachingDbContext coachingDbContext, IConfiguration configuration)
        {
            _coachingDbContext = coachingDbContext;
            _configuration = configuration;
        }


        public async Task<string> Register(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match.");
            }
            var exists = await _coachingDbContext.Users.AnyAsync(u => u.Username == registerDto.Username);

            if (exists)
            {
                throw new Exception("Username already exists.");
            }
            var user = new User
            {
                Username = registerDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Role = "User"

            };
            await _coachingDbContext.Users.AddAsync(user);
            await _coachingDbContext.SaveChangesAsync();

            return "User registered successfully.";
        }
        public async Task<string> AdminRegister(RegisterDto registerDto)
        {
            if(registerDto.Password != registerDto.ConfirmPassword)
            {
                throw new Exception("Password and Confirm Password do not match.");
            }
            var exists = await _coachingDbContext.Users.AnyAsync(m => m.Username == registerDto.Username);
            if (exists)
            {
                throw new Exception("Username already exists.");
            }
            var user = new User
            {
                Username = registerDto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Role = "Admin"
            };
            await _coachingDbContext.Users.AddAsync(user);
            await _coachingDbContext.SaveChangesAsync();
            return "Admin registered successfully.";
        }

        public async Task<string> Login(LoginDtos loginDto)
        {
           var user = await _coachingDbContext.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }
            bool isValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);
            if (!isValid)
            {
                throw new Exception("Invalid username ya password");
            }
            return GenerateToken(user);
        }
        private string GenerateToken(User user)
        {
            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role)

            };
            var key = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_configuration["JWT:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

       
    }
}
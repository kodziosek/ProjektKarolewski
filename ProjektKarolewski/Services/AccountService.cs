using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjektKarolewski.Controllers;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Exceptions;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKarolewski.Services
{
    
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
        void ChangePassword(int userId, RegisterUserDto dto);
        IEnumerable<UserDto> GetAll();
        void Update(int id, UpdateUserDto dto);
        void RemoveById(int userId);
    }
    public class AccountService : IAccountService
    {
        private readonly ProjektDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IMapper _mapper;

        public AccountService(ProjektDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _mapper = mapper;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                RoleId = dto.RoleId
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void ChangePassword(int userId, RegisterUserDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == userId);

            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);

            user.PasswordHash = hashedPassword;
            _context.SaveChanges();
        }
        public void RemoveById(int userId)
        {

            var user = _context.Users
                .FirstOrDefault(i => i.Id == userId);
            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            var userDto = _mapper.Map<UserDto>(user);

            _context.Remove(user);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateUserDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == id);


            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.RoleId = dto.RoleId;

            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);

            user.PasswordHash = hashedPassword;

            _context.SaveChanges();
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _context
                .Users
                .Include(i => i.Role)
                .ToList();

            var userDtos = _mapper.Map<List<UserDto>>(users);

            return userDtos;
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Username == dto.Username);

            if(user is null)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password.");
            }
            var claims = new List<Claim>() 
            { 
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Username}"),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims, expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}

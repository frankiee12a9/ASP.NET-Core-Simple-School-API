using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SchoolApiSrc.Services.IServices;
using SchoolApiSrc.Models;
using System.Threading.Tasks;
using SchoolApiSrc.Data;
using SchoolApiSrc.Extensions;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolApiSrc.Services
{
    public class AuthService : IAuthService
    {
        private readonly SchoolContext _db;
        private readonly IConfiguration _config;

        public AuthService(SchoolContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public void Delete(int id)
        {
            var userToDelete = _db.AppLoginInfos.FirstOrDefault(x => x.AppLoginId == id);
            if (userToDelete is null)
            {
                return;
            }

            _db.AppLoginInfos.Remove(userToDelete);
        }

        public async Task<IEnumerable<AppLoginInfo>> GetAll()
        {
            return await _db.AppLoginInfos
                .OrderBy(u => u.UserType)
                .ToListAsync();
        }

        public async Task<AppLoginInfo> GetOne(string userName)
        {
            var authenciatedUser = await _db.AppLoginInfos
                .FirstOrDefaultAsync(x => x.Username == userName);

            return authenciatedUser;
        }

        public async Task<bool> IsAccountExists(string userName)
        {
            return await _db.AppLoginInfos.AnyAsync(x => x.Username.ToLower() == userName.ToLower());
        }

        public async Task<bool> Login(string userName, string password)
        {
            var account = await _db.AppLoginInfos.FirstOrDefaultAsync(x => x.Username == userName);

            if (account is null || !BCrypt.Net.BCrypt.Verify(account.Password, account.HashedPassword))
            {
                return false;
            }

            // authenticate with jwt
            // need login to get the jwt to access other services
            account.JwtKey = CreateToken(account);
            Console.Write(account.JwtKey);
            return true;
        }

        public async Task Register(AppLoginInfo account)
        {
            account.HashedPassword = BCrypt.Net.BCrypt.HashPassword(account.Password);

            // verify that current registered user is Lectuerer or student
            if (account.UserType.Equals("Professor"))
            {
                account.UserType = Helpers.ProfessorType;
            }
            else if (account.UserType.Equals("Teaching Assistant"))
            {
                account.UserType = Helpers.TAType;
            }
            else
            {
                account.UserType = Helpers.StudentType;
            }

            await _db.AppLoginInfos.AddAsync(account);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        private string CreateToken(AppLoginInfo account)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, account.AppLoginId.ToString()),
                new Claim(ClaimTypes.Name, account.Username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),  // add expiration time for jwt
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
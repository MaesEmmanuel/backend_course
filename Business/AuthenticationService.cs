﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business
{
    public class AuthenticationService: IAuthenticationService
    {
 
        private readonly List<User> users = new()
        {
            new User("user1","829792F8543443A91F7E","Sunday"),  //test
            new User("user2","EE1D043DE283E12CD10A","Sunday"), //password
            new User("user3","A06EE0913A1EBFCE55EF","Sunday") //secret
        };

        IConfiguration _config;
        public AuthenticationService(IConfiguration config)
        {
            _config = config;
        }
        private string GenerateJSONWebToken(string username)
        {
            var secretKey = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Assume you have a user object with roles
            var userRoles = new List<string> { "Admin", "User" };

            // Create a ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity();

            // Add claims for roles
            foreach (var role in userRoles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Sub, username),
                 new Claim("custom_info", "info"),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            claimsIdentity.AddClaims(claims);

            var jwtIssuer = _config["Jwt:Issuer"];
            var jwtAudience = _config["Jwt:Audience"];

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claimsIdentity.Claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password, string salt)
        {

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                        password: Encoding.UTF8.GetBytes(password),
                        salt: Encoding.UTF8.GetBytes(salt),
                        iterations: 10,
                        hashAlgorithm: HashAlgorithmName.SHA512,
                        outputLength: 10);
            return Convert.ToHexString(hash);
        }

        public void RegisterUser(string username, string password)
        {
            if (users.Any(user => user.Username.ToLower() == username.ToLower()))
            {
                throw new Exception("User already exist");
            }
            var salt = DateTime.Now.ToString("dddd"); // get the day of week. Ex: Sunday
            var passwordHash = HashPassword(password, salt);
            var newUser = new User(username, passwordHash, salt);
            users.Add(newUser);
        }


        public string Login(string username, string password)
        {
            var user = users.FirstOrDefault(user => user.Username.ToLower() == username.ToLower()) ??
                            throw new Exception("Login failed; Invalid userID or password");

            var passwordHash = HashPassword(password, user.Salt);
            if (user.Password == passwordHash)
            {
                var token = GenerateJSONWebToken(username);
                return token;
            }
            throw new Exception("Login failed; Invalid userID or password");
        }
    }
}
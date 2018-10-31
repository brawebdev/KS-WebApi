using KS.Business.DataContract.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KS.Business.Engines.Authorization
{
    class GenerateTokenEngine
    {
        private readonly IConfiguration _config;

        public GenerateTokenEngine(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateTokenString(ReceivedExistingUserDTO receivedExistingUserDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();           //v-- TODO: Add private in appsettings.json
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, receivedExistingUserDTO.Id.ToString()),
                    new Claim(ClaimTypes.Name, receivedExistingUserDTO.Username)
                }),
                Expires = DateTime.Now.AddDays(1),

                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), // <---Note the key.
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}

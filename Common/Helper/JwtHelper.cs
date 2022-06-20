using LuckCode.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Common.Helper
{
    public class JwtHelper:IJwtHelper
    {
        private JWTTokenOptions _JwtTokenOption;

        public JwtHelper(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions)
        {
            _JwtTokenOption = jwtTokenOptions.CurrentValue;
        }
        public string GetJWTToken(sysuser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),

                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier,user.Account),             
                new Claim(ClaimTypes.Role, user.RoleId),
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtTokenOption.SecurityKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer: _JwtTokenOption.Issuer,
                audience: _JwtTokenOption.Audience, claims: claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
            string rtoken = new JwtSecurityTokenHandler().WriteToken(token);
            return rtoken;
        }
    }
    public class JWTTokenOptions
    {
        public string Audience { get; set; }
        public string SecurityKey { get; set; }

        public string Issuer { get; set; }
    }
}

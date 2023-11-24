using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Online_Hairdresser.Core.Helpers.Security.Encryption;
using Online_Hairdresser.Models.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Online_Hairdresser.Core.Helpers.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenoptions;
        DateTime _accessTokenExp;
        DateTime _refreshTokenExp;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenoptions = Configuration.GetSection("Jwt").Get<TokenOptions>();

        }
        public AccessToken CreateToken(RolesEnum rolesEnum, int id, int cityCountyId=0)
        {
            _accessTokenExp = DateTime.Now.AddMinutes(_tokenoptions.AccessTokenExpretion);
            _refreshTokenExp = DateTime.Now.AddMinutes(_tokenoptions.RefreshTokenExpretion);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenoptions.Key);
            var signingCredentials = SigningCreditianalsHelper.CreateSigningCreditianals(securityKey);
            var jwt = CreateJwtSecurityWebToken(_tokenoptions, signingCredentials, rolesEnum, id,cityCountyId);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            var refreshToken = GenerateRefreshToken();
            
            return new AccessToken
            {
                Token = token,
                ExpirationDate = _accessTokenExp,
                RefreshExpirationDate = _refreshTokenExp,
                RefreshToken = refreshToken
            };

        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenoptions.Key)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            
            return principal;

        }
        private JwtSecurityToken CreateJwtSecurityWebToken(TokenOptions tokenOptions, SigningCredentials signingCredentials, RolesEnum rolesEnum, int id,int cityCountyId=0)
        {
            var jwt = new JwtSecurityToken
            (
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExp,
                notBefore: DateTime.Now,
                claims: SetClaims(rolesEnum, id,cityCountyId),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(RolesEnum rolesEnum, int id,int cityCountyId=0)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("AccountRole", rolesEnum.ToString()));
            claims.Add(new Claim("Id", id.ToString()));
            claims.Add(new Claim("CityCountyId", cityCountyId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, rolesEnum.ToString()));
            return claims;
        }
    }
}

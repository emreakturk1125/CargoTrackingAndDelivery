using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs; 

namespace TekhnelogosInterviewProject.Service.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions tokenOptions;

        public TokenHandler(IOptions<TokenOptions> tokenOptions)
        {
            this.tokenOptions = tokenOptions.Value;
        }

        public AccessTokenDto CreateAccessToken(Personal personal)
        {
            var accessTokenExpiration = DateTime.Now.AddHours(tokenOptions.AccessTokenExpiration);

            var securityKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaim(personal),
                signingCredentials: signingCredentials

                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            AccessTokenDto accessToken = new AccessTokenDto();

            accessToken.Token = token;
            //accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;

            return accessToken;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);

                return Convert.ToBase64String(numberByte);
            }
        }

        private IEnumerable<Claim> GetClaim(Personal personal)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,personal.PersonalId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,personal.UserName),  // email yerine kullanıcı adı
                new Claim(ClaimTypes.Name,$"{personal.PersonalName} {personal.PersonalSurname}"),
                new  Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return claims;
        }

        public void RevokeRefreshToken(Personal personel)
        {
            
        }
    }
}
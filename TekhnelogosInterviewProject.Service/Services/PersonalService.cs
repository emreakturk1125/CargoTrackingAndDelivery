using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Core.UnitOfWorks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.HelperConcrete;
using TekhnelogosInterviewProject.Service.Constants;
using Microsoft.Extensions.Configuration;
using TekhnelogosInterviewProject.Helper.Response;
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.Service.Security.Token;

namespace TekhnelogosInterviewProject.Service.Services
{
    public class PersonalService : Service<Personal>, IPersonalService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenHandler _tokenHandler;

        public PersonalService(IUnitOfWork unitOfWork, IRepository<Personal> repository, IConfiguration configuration, ITokenHandler tokenHandler) : base(unitOfWork, repository)
        {
            _configuration = configuration;
            _tokenHandler = tokenHandler;

        }

        // ilk yaptığım token metodu
        public async Task<BaseResponse<TokenResultDto>> GetPersonalByUsernameAndPasswordAsync(string username, string password)
        {
            var result = await _unitOfWork.Personals.SingleOrDefaultAsync(x => x.UserName == username && x.UserPassword == password);

            TokenResultDto tr = new TokenResultDto();

            if (result == null)
            {
                tr.Description = Messages.NotCreatedToken;
                return new BaseResponse<TokenResultDto>(tr);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration["JwtConfig:SecretKey"]); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            tr.Token = tokenHandler.WriteToken(token);
            tr.Description = Messages.CreatedToken;
            tr.PersonalId = result.PersonalId;

            return new BaseResponse<TokenResultDto>(tr);

        }

        // Uygulamada kullandığım token metodu
        public async Task<BaseResponse<AccessTokenDto>> CreateAccessToken(string username, string userpassword)
        {
            var  personal = await _unitOfWork.Personals.SingleOrDefaultAsync(x => x.UserName == username && x.UserPassword == userpassword);
            AccessTokenDto accessToken = _tokenHandler.CreateAccessToken(personal);
            return new BaseResponse<AccessTokenDto>(accessToken);
           
        }

        public async Task<BaseResponse<IEnumerable<Personal>>> GetPersonalListWithRoleAsync()
        {
            IEnumerable<Personal> response = await _unitOfWork.Personals.GetPersonalListWithRoleAsync();
            return new BaseResponse<IEnumerable<Personal>>(response);
        }

         
        public async Task<BaseResponse<Personal>> GetPersonalWithRoleByIdAsync(int personalId)
        {
            Personal response = await _unitOfWork.Personals.GetPersonalWithRoleByIdAsync(personalId);
            return new BaseResponse<Personal>(response);
        }
    }
}

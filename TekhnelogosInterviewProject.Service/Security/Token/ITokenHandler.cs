using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs;

namespace TekhnelogosInterviewProject.Service.Security.Token
{
    public interface ITokenHandler
    {
        AccessTokenDto CreateAccessToken(Personal personal);

        void RevokeRefreshToken(Personal personal);
    }
}
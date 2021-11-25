using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.Entity.HelperConcrete;
using TekhnelogosInterviewProject.Helper.Response;

namespace TekhnelogosInterviewProject.Core.Services
{
    // Repository ile Servis arasındaki fark 
    // Repository içinde direk veritabanı işlemleri tanımlanır
    // IPersonalService ise veritabanı ile alakalı olmayan işlemler tanımlanabilir. Product'a özel metodlar (Örnek olarak ControlInnerBarcode metodu)
    public interface IPersonalService : IService<Personal>
    { 
        Task<BaseResponse<Personal>> GetPersonalWithRoleByIdAsync(int personalId);
        Task<BaseResponse<TokenResultDto>> GetPersonalByUsernameAndPasswordAsync(string username, string password);
        Task<BaseResponse<IEnumerable<Personal>>> GetPersonalListWithRoleAsync();
        Task<BaseResponse<AccessTokenDto>> CreateAccessToken(string username, string userpassword);


    }
}

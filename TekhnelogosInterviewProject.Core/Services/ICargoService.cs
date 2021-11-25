using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Helper.Response;

namespace TekhnelogosInterviewProject.Core.Services
{
    public interface ICargoService : IService<Cargo>
    {
        Task<BaseResponse<Cargo>> GetCargoWithCustomerAndPersonalByIdAsync(int cargoId);
        Task<BaseResponse<IEnumerable<Cargo>>> GetCargoWithCustomerAndPersonalListByDateAsync();

    }
}

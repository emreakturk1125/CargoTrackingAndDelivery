using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Core.UnitOfWorks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Helper.Response;

namespace TekhnelogosInterviewProject.Service.Services
{
    public class CargoService : Service<Cargo>, ICargoService
    {
        public CargoService(IUnitOfWork unitOfWork, IRepository<Cargo> repository) : base(unitOfWork, repository)
        {
        }
         
        public async Task<BaseResponse<Cargo>> GetCargoWithCustomerAndPersonalByIdAsync(int cargoId)
        {
            Cargo response = await _unitOfWork.Cargos.GetCargoWithCustomerAndPersonalByIdAsync(cargoId);
            return new BaseResponse<Cargo>(response);
             
        }

        public async Task<BaseResponse<IEnumerable<Cargo>>> GetCargoWithCustomerAndPersonalListByDateAsync()
        {
            IEnumerable<Cargo> response = await _unitOfWork.Cargos.GetCargoWithCustomerAndPersonalByDateAsync();
            return new BaseResponse<IEnumerable<Cargo>>(response);
        }
    }
}

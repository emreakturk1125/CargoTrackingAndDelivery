using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Core.Repositories
{
    public interface ICargoRepository : IRepository<Cargo>
    {
        Task<Cargo> GetCargoWithCustomerAndPersonalByIdAsync(int cargoId);
        Task<IEnumerable<Cargo>> GetCargoWithCustomerAndPersonalByDateAsync();
    }
}

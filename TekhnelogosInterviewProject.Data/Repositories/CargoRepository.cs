using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Repositories
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CargoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cargo> GetCargoWithCustomerAndPersonalByIdAsync(int cargoId)
        {
           return await _appDbContext.Cargos.Include(x => x.Customer).Include(x => x.Personal).SingleOrDefaultAsync(x => x.CargoId == cargoId);
        }

        public async Task<IEnumerable<Cargo>> GetCargoWithCustomerAndPersonalByDateAsync()
        {
            return await _appDbContext.Cargos.Include(x => x.Customer).Include(x => x.Personal).ToListAsync();
        }
    }
}

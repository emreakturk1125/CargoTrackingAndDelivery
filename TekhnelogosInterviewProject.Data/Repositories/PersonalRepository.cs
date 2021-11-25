using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Repositories
{
    public class PersonalRepository : Repository<Personal>, IPersonalRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public PersonalRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Personal> GetPersonalWithRoleByIdAsync(int personalId)
        {
            return await _appDbContext.Personals.Include(x => x.Role).SingleOrDefaultAsync(x => x.PersonalId == personalId);

        }

        public async Task<IEnumerable<Personal>> GetPersonalListWithRoleAsync()
        {
            return await _appDbContext.Personals.Include(x => x.Role).ToListAsync();

        }
 
    }
}

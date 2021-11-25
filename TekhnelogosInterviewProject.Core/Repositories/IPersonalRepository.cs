using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete; 

namespace TekhnelogosInterviewProject.Core.Repositories
{
    public interface IPersonalRepository : IRepository<Personal>
    {
        Task<Personal> GetPersonalWithRoleByIdAsync(int personalId); 

        Task<IEnumerable<Personal>> GetPersonalListWithRoleAsync();
         

    }
}

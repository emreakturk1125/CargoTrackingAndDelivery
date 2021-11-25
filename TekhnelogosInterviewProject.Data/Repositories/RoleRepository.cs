using System;
using System.Collections.Generic;
using System.Text;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}

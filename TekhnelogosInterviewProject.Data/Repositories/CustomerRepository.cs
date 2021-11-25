using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
 
    }
}

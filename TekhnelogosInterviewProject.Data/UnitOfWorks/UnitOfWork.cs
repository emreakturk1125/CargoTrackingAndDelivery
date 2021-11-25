using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Core.UnitOfWorks;
using TekhnelogosInterviewProject.Data.Repositories;

namespace TekhnelogosInterviewProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private  CargoRepository _cargoRepository;
        private  CustomerRepository _customerRepository;
        private  PersonalRepository _personalRepository;
        private  RoleRepository _roleRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext; 
        }
        public ICargoRepository Cargos => _cargoRepository  ?? new CargoRepository(_context);
        public ICustomerRepository Customers => _customerRepository  ?? new CustomerRepository(_context);
        public IPersonalRepository Personals => _personalRepository  ?? new PersonalRepository(_context);
        public IRoleRepository Roles => _roleRepository ?? new RoleRepository(_context); 

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();

        }
    }
}

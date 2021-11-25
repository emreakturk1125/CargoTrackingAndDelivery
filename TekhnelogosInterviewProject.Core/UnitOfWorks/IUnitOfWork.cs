using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;

namespace TekhnelogosInterviewProject.Core.UnitOfWorks
{
        public interface IUnitOfWork
        {
            ICargoRepository Cargos { get; }
            ICustomerRepository Customers { get; }
            IPersonalRepository Personals { get; }
            IRoleRepository Roles { get; }
            Task CommitAsync(); // Asenkron olan metod
            void Commit(); // Asenkron olmayan metod
        }
}

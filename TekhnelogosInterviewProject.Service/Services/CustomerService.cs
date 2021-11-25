using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Core.UnitOfWorks;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> repository) : base(unitOfWork, repository)
        {
        }
         
    }
}

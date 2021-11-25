using System;
using System.Collections.Generic;
using System.Text;
using TekhnelogosInterviewProject.Core.Repositories;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Core.UnitOfWorks;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Service.Services
{
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IRepository<Role> repository) : base(unitOfWork, repository)
        {
        }
    }
}

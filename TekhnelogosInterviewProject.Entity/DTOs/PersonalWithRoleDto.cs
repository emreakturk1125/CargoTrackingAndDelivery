using System;
using System.Collections.Generic;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.DTOs
{
    public class PersonalWithRoleDto : PersonalDto
    {
        public RoleDto Role { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.Concrete
{
    public class Role
    {
        public Role()
        {
            Personals = new Collection<Personal>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Personal> Personals { get; set; }

    }
}

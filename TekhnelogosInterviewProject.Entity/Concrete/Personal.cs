using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.Concrete
{
    public class Personal
    {
        public Personal()
        {
            Cargos = new Collection<Cargo>();
        }
        public int PersonalId { get; set; }
        public string UserName { get; set; }
        public string PersonalName { get; set; }
        public string PersonalSurname { get; set; }
        public string UserPassword { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } 
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Cargo> Cargos { get; set; }

    }
}

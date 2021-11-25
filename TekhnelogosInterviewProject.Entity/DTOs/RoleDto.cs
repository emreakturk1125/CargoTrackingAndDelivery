using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.DTOs
{
    public class RoleDto
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "RoleName alanı gereklidir")]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}
 
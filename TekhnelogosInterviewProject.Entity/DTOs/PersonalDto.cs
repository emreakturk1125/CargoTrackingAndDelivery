using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.DTOs
{
    public class PersonalDto
    {
        public int PersonalId { get; set; }

        [Required(ErrorMessage = "PersonalName alanı gereklidir")]
        public string PersonalName { get; set; }

        [Required(ErrorMessage = "PersonalSurname alanı gereklidir")]
        public string PersonalSurname { get; set; }

        [Required(ErrorMessage = "UserName alanı gereklidir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "UserPassword alanı gereklidir")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "RoleId alanı gereklidir")]
        public int RoleId { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}

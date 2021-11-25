using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "CustomerName alanı gereklidir")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "CustomerSurname alanı gereklidir")]
        public string CustomerSurname { get; set; }

        [Required(ErrorMessage = "CustomerAddress alanı gereklidir")]
        public string CustomerAddress { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

    }
} 
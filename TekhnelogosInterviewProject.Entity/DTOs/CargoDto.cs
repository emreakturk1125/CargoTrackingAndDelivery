using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.DTOs
{
    public class CargoDto
    {
        public int CargoId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string CargoName { get; set; }
         
        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı gereklidir")] 
        public int CustomerId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı gereklidir")]
        public int PersonalId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public decimal CargoPrice { get; set; }

        [Range(typeof(DateTime), "1/1/2000", "1/1/2100", ErrorMessage = "{0} alanı gereklidir")]
        public DateTime ShippingDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public bool IsActive { get; set; }
    }
}

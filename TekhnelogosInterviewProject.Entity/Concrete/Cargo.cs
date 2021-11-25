using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.Concrete
{
    public class Cargo
    { 
        public int CargoId { get; set; }
        public string CargoName { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int PersonalId { get; set; }
        public virtual Personal Personal { get; set; }
        public decimal CargoPrice { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool IsActive { get; set; }
         
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TekhnelogosInterviewProject.Entity.Concrete
{
    public class Customer
    {
        public Customer()
        {
            Cargos = new Collection<Cargo>();
        }
        public int CustomerId { get; set; } 
        public string CustomerName { get; set; } 
        public string CustomerSurname { get; set; } 
        public string CustomerAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Cargo> Cargos { get; set; }



    }
}

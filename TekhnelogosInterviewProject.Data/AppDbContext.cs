using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TekhnelogosInterviewProject.Data.Configuration;
using TekhnelogosInterviewProject.Entity.Concrete;

namespace TekhnelogosInterviewProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Personal> Personals { get; set; }   
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Veritabanı oluşmadan önce çalışacak metod
        {
            // Önce tablolar oluşacak
            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration()); 
        }
    }
}

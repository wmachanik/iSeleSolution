using System;
using System.Collections.Generic;
using System.Text;
using iSele.Models.Customers;
using iSele.Models.General;
using iSele.Services.EntityConfigs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace iSele.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // customers
        public DbSet<Customer> Customers { get; set; }
        // general
        public DbSet<Area> Areas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Add all databases into the model
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.ApplyConfiguration(new CustomerModelConfiguration());

        }
    }
}

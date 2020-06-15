using System;
using System.Collections.Generic;
using System.Text;
using iSele.Models.Accounts;
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

        // accounts
        #region AccDBStuff
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PriceGroup> PriceGroups { get; set; }
        public DbSet<PriceLevel> PriceLevels { get; set; }
        public DbSet<PriceListType> PriceListTypes { get; set; }
        public DbSet<PriceTypeByPercent> PriceTypeByPercents { get; set; }
        public DbSet<PriceTypeByValue> PriceTypeByValues { get; set; }
        public DbSet<VATTaxType> VATTaxTypes { get; set; }
        #endregion
        // customers
        #region CustomerDBStuff
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<CustomerAccountingOptions> CustomerAccountingOptions { get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public DbSet<CustomerPostalAddress> CustomerPostalAddresses { get; set; }
        public DbSet<CustomerShippingAddress> CustomerShippingAddresses { get; set; }
        #endregion 
        // general
        public DbSet<Area> Areas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Add all databases into the model
            // account database stuff
            #region AccDBStuff
            modelBuilder.Entity<InvoiceType>().ToTable("InvoiceTypes");
            modelBuilder.ApplyConfiguration<InvoiceType>(new InvoiceTypeConfiguration());
            modelBuilder.Entity<PaymentTerm>().ToTable("PaymentTerms");
            modelBuilder.ApplyConfiguration<PaymentTerm>(new PaymentTermConfiguration());
            modelBuilder.Entity<PaymentType>().ToTable("PaymentTypes");
            modelBuilder.ApplyConfiguration<PaymentType>(new PaymentTypeConfiguration());
            modelBuilder.Entity<PriceGroup>().ToTable("PriceGroups");
            modelBuilder.ApplyConfiguration<PriceGroup>(new PriceGroupConfiguration());
            modelBuilder.Entity<PriceLevel>().ToTable("PriceLevels");
            modelBuilder.ApplyConfiguration<PriceLevel>(new PriceLevelConfiguration());
            modelBuilder.Entity<PriceListType>().ToTable("PriceListTypes");
            modelBuilder.ApplyConfiguration<PriceListType>(new PriceListTypeConfiguraton());
            modelBuilder.Entity<PriceTypeByPercent>().ToTable("PriceTypeByPercents");
            modelBuilder.ApplyConfiguration<PriceTypeByPercent>(new PriceTypeByPercentConfiguration());
            modelBuilder.Entity<PriceTypeByValue>().ToTable("PriceTypeByValues");
            modelBuilder.ApplyConfiguration<PriceTypeByValue>(new PriceTypeByValueConfiguration());
            modelBuilder.Entity<VATTaxType>().ToTable("VATTaxTypes");
            modelBuilder.ApplyConfiguration<VATTaxType>(new VATTaxTypeConfiguration());
            #endregion
            // customer database stuff
            #region CustomerDBStuff
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.ApplyConfiguration<Customer>(new CustomerModelConfiguration());

            modelBuilder.Entity<CustomerContact>().ToTable("CustomerContacts");
            modelBuilder.ApplyConfiguration<CustomerContact>(new CustomerContactConfiguration());

            modelBuilder.Entity<CustomerAccountingOptions>().ToTable("CustomerAccountingOptions");
            modelBuilder.ApplyConfiguration<CustomerAccountingOptions>(new CustomerAccountingOptionsConfiguration());

            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.ApplyConfiguration<Address>(new AddressConfiguration());

            modelBuilder.Entity<CustomerPostalAddress>().ToTable("CustomerPostalAddresses")
                .HasKey(cadr => new { cadr.CustomerID, cadr.AddressID });
            modelBuilder.Entity<CustomerShippingAddress>().ToTable("CustomerShippingAddresses")
                .HasKey(cadr => new { cadr.CustomerID, cadr.AddressID });
            #endregion

        }
    }
}

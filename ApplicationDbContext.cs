using System;
using System.Collections.Generic;
using System.Text;
using congestion.calculator.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace congestion.calculator
{
    

    public class ApplicationDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<CongestionConfig> CongestionConfigs { get; set; }
        public DbSet<CongestionTax> CongestionTaxes { get; set; }
        public DbSet<OffDay> OffDays { get; set; }
        public DbSet<OffDate> OffDates { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleTaxInfo> VehicleTaxInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // City
            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);

            // CongestionConfig
            modelBuilder.Entity<CongestionConfig>()
                .HasKey(cc => cc.Id);
            modelBuilder.Entity<CongestionConfig>()
                .HasOne(cc => cc.City)
                .WithMany(c => c.CongestionConfigs)
                .HasForeignKey(cc => cc.CityId);

            // CongestionTax
            modelBuilder.Entity<CongestionTax>()
                .HasKey(ct => ct.Id);
            modelBuilder.Entity<CongestionTax>()
                .HasOne(ct => ct.City)
                .WithMany(c => c.CongestionTaxes)
                .HasForeignKey(ct => ct.CityId);

            // OffDay
            modelBuilder.Entity<OffDay>()
                .HasKey(od => od.Id);
            modelBuilder.Entity<OffDay>()
                .HasOne(od => od.City)
                .WithMany(c => c.OffDays)
                .HasForeignKey(od => od.CityId);

            // OffDate
            modelBuilder.Entity<OffDate>()
                .HasKey(od => od.Id);
            modelBuilder.Entity<OffDate>()
                .HasOne(od => od.City)
                .WithMany(c => c.OffDates)
                .HasForeignKey(od => od.CityId);

            // VehicleType
            modelBuilder.Entity<VehicleType>()
                .HasKey(vt => vt.Id);

            // VehicleTaxInfo
            modelBuilder.Entity<VehicleTaxInfo>()
                .HasKey(vti => vti.Id);
            modelBuilder.Entity<VehicleTaxInfo>()
                .HasOne(vti => vti.City)
                .WithMany(c => c.VehicleTaxInfos)
                .HasForeignKey(vti => vti.CityId);
            modelBuilder.Entity<VehicleTaxInfo>()
                .HasOne(vti => vti.VehicleType)
                .WithMany(vt => vt.VehicleTaxInfos)
                .HasForeignKey(vti => vti.VehicleId);
        }
    }

}

using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess
{
    public class EmporoContext : DbContext
    {
        public EmporoContext(DbContextOptions<EmporoContext> options) : base(options) { }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemVendor> ItemVendor { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<PharmacyInventory> PharmacyInventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder
            .Entity<Hospital>()
            .Property(t => t.HospitalId)
            .IsRequired();

            modelBuilder
            .Entity<Item>()
            .Property(t => t.ItemId)
            .IsRequired();

            modelBuilder
            .Entity<Item>()
            .HasIndex(t => new { t.ItemNumber })
            .IsUnique(true);

            modelBuilder
            .Entity<ItemVendor>()
            .Property(t => t.ItemVendorId)
            .IsRequired();

            modelBuilder
            .Entity<Pharmacy>()
            .Property(t => t.PharmacyId)
            .IsRequired();

            modelBuilder
            .Entity<PharmacyInventory>()
            .Property(t => t.PharmacyInventoryId)
            .IsRequired();
        }
    }
}

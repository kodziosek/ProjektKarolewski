using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjektKarolewski.Entities
{
    public class ProjektDbContext : DbContext
    {
        private string _connectionString =
            "Server=LAPTOP-9GMMPIUH; Database=ProjektDb;Trusted_Connection=True";
        public DbSet<Device> Devices { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Device>()
                .Property(d => d.NameInPassport);

            modelBuilder.Entity<Device>()
                .Property(d => d.AcquisitionDate)
                .HasMaxLength(50);

            modelBuilder.Entity<Device>()
                .Property(d => d.ProductionDate)
                .HasMaxLength(50);

            modelBuilder.Entity<Device>()
                .Property(d => d.PassportNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<Device>()
                .Property(d => d.InventoryNumber)
                .HasMaxLength(50);

            modelBuilder.Entity<Ward>()
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Inspection>()
                .Property(i => i.InspectionDate)
                .IsRequired();

            modelBuilder.Entity<Inspection>()
                .Property(i => i.InspectionFrequency)
                .IsRequired();

            modelBuilder.Entity<InspectionType>()
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Contract>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Service>()
                .Property(s => s.ServiceName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Service>()
                .Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Producer>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Ticket>()
                .Property(f => f.TicketDate)
                .IsRequired();


            modelBuilder.Entity<Reply>()
                .Property(r => r.ReplyDate)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<User>()
                .Property(r => r.Username)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(30);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

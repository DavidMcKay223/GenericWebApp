using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Management
{
    public class ManagementContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TaskSubType> TaskSubTypes { get; set; }
        public DbSet<TaskObjectType> TaskObjectTypes { get; set; }
        public DbSet<TaskActivity> TaskActivities { get; set; }
        public DbSet<CMS1500Form> CMS1500Forms { get; set; }
        public DbSet<Claimant> Claimants { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection", options =>
                    options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claimant>()
                .HasOne(c => c.PrimaryAddress)
                .WithMany()
                .HasForeignKey(c => c.PrimaryAddressID)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict to avoid multiple cascade paths

            modelBuilder.Entity<Claimant>()
                .HasOne(c => c.SecondaryAddress)
                .WithMany()
                .HasForeignKey(c => c.SecondaryAddressID)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict to avoid multiple cascade paths

            modelBuilder.Entity<CMS1500Form>()
                .HasOne(f => f.Claimant)
                .WithMany()
                .HasForeignKey(f => f.ClaimantID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

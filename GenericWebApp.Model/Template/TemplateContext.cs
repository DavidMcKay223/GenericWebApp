using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericWebApp.Model.Template;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Template
{
    public class TemplateContext : DbContext
    {
        public DbSet<TemplateItem> TemplateItems { get; set; }
        public DbSet<TemplateStatus> TemplateStatus { get; set; }

        public TemplateContext()
        {
        }

        public TemplateContext(DbContextOptions<TemplateContext> options) : base(options)
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TemplateItem>()
                .HasOne(c => c.PrimaryAddress)
                .WithMany()
                .HasForeignKey(c => c.PrimaryAddressID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TemplateItem>()
                .HasOne(c => c.SecondaryAddress)
                .WithMany()
                .HasForeignKey(c => c.SecondaryAddressID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

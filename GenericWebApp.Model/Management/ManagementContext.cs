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

        }
    }
}

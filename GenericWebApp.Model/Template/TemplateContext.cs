using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericWebApp.Model.Music;
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
        }
    }
}

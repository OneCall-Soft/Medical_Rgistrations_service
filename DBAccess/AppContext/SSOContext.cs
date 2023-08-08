using DBAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DBAccess.AppContext
{
    public class SSOContext : DbContext
    {
        public SSOContext(DbContextOptions<SSOContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            

        }
        //entities
        public DbSet<SSORegistrations> Registrations { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Genders> Gender { get; set; }
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<CompanyInfo> Company { get; set; }
        public DbSet<PageTemplete> Templetes { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Gallary> Gallary { get; set; }
        public DbSet<DashboardLink> DashboardLink { get; set; }
    }

    public static class ModelBinderExtension {

        public static void Seed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Genders>().HasData(new Genders { Id = 1, Value = "Male" },
                new Genders { Id = 2, Value = "Female" }, new Genders { Id = 3, Value = "Others" });
        }

    }
}

using CityLight.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CityLight.Repository
{
    public class CitylightDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Citylight> Citylights { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CitylightDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Citylight>().ToTable("Citylights");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShopApi.Models;

namespace WebShopApi.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("WebApiDatabase");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        public DbSet<ClothesItem> ClothesItems {get; set;} = null!;
        public DbSet<ClothesType> ClothesTypes {get; set;} = null!;
        public DbSet<Customer> Customers {get; set;} = null!;
        public DbSet<Order> Orders {get; set;} = null!;
        public DbSet<JoiningOrderClothesItem> JoiningOrderClothesItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClothesItem>()
                .HasOne(ci => ci.ClothesType)
                .WithMany() // No navigation property in ClothesType
                .HasForeignKey(ci => ci.ClothesTypeId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull); // If customer is deleted, keep the orders but set null for CustomerId

            modelBuilder.Entity<JoiningOrderClothesItem>()
                .HasKey(j => new { j.OrderId, j.ClothesItemId }); // Composite primary key

            modelBuilder.Entity<JoiningOrderClothesItem>()
                .HasOne(j => j.Order)
                .WithMany(o => o.OrderClothesItems)
                .HasForeignKey(j => j.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JoiningOrderClothesItem>()
                .HasOne(j => j.ClothesItem)
                .WithMany(ci => ci.OrderClothesItems)
                .HasForeignKey(j => j.ClothesItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShoping.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoping.Infrastructure.Data
{
    public class OnlineShopingDbContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration configuration { get; }

        public OnlineShopingDbContext(DbContextOptions<OnlineShopingDbContext> options,   IConfiguration configuration ) : base(options)
        {
            this.configuration = configuration;
        }
        public DbSet<UOM> UOM { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          

            // Seed UOM data
            modelBuilder.Entity<UOM>().HasData(

                new UOM { UomId = 1, Uom = "kg", Description = "Kilogram" },
                new UOM { UomId = 2, Uom = "Gm", Description = "Gram" }

            );

            // Seed Customer data
            modelBuilder.Entity<Customers>().HasData(
                new Customers { Id = 1000, CustomerName = "Mhammad", UserName = "Mhammad.1", password = "Mh1212" },
                new Customers { Id = 2000, CustomerName = "Ahmad", UserName = "Ahmad.290", password = "Ah1212" }

            );
            modelBuilder.Entity<Orders>().HasData(
            new Orders
            {
                Id = 1,
                RequestDate = new DateTime(2024, 01, 26),
                CloseDate = null,
                Status = "Open",
                CustomerId = 1000,
                DiscountPromoCode = "VS02",
                DiscountValue = 60.00m,
                TotalPrice = 3940.00m,
                CurrencyCode = "EGP",
                ExchangeRate = 1,
                ForignPrice = 3940.00m
            },
            new Orders
            {
                Id = 2,
                RequestDate = new DateTime(2024, 01, 27),
                CloseDate = new DateTime(2019, 03, 27),
                Status = "Close",
                CustomerId = 2000,
                DiscountPromoCode = "0",
                DiscountValue = 0,
                TotalPrice = 2800.00m,
                CurrencyCode = "USD",
                ExchangeRate = 30,
                ForignPrice = 93.33m
            },
            new Orders
            {
                Id = 3,
                RequestDate = new DateTime(2024, 01, 29),
                CloseDate = null,
                Status = "Open",
                CustomerId = 1000,
                DiscountPromoCode = "0",
                DiscountValue = 0,
                TotalPrice = 4500.00m,
                CurrencyCode = "USD",
                ExchangeRate = 30,
                ForignPrice = 150.00m
            }

             );
            // Seed Item data
            modelBuilder.Entity<Items>().HasData(
                new Items { Id = 1, ItemName = "A1", Description = "Desc 1", QTY = 10000, Price = 1500, UomId = 1 },
                new Items { Id = 2, ItemName = "A2", Description = "Desc 2", QTY = 2500, Price = 2800, UomId = 1 },
                new Items { Id = 3, ItemName = "A3", Description = "Desc 3", QTY = 3700, Price = 200, UomId = 1 }

            );
            // Seed OrderDetail data
            modelBuilder.Entity<OrderDetails>().HasData(
                new OrderDetails { Id = 1, OrderId = 1, ItemId = 1, ItemPrice = 1500, Quantity = 2, TotalPrice = 3000 },
                new OrderDetails { Id = 2, OrderId = 2, ItemId = 2, ItemPrice = 2800, Quantity = 1, TotalPrice = 2800 },
                new OrderDetails { Id = 3, OrderId = 3, ItemId = 1, ItemPrice = 1500, Quantity = 3, TotalPrice = 4500 }
            // Add more OrderDetail seed data as needed
            );
        }
    }
}

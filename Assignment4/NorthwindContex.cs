﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Assignment4
{
    public class NorthwindContex : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetailsTable { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=vfh");
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=Pluto25");
            
            // optionsBuilder.UseLoggerFactory(MyLoggerFactory)
            //     .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("categories");
            //modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

            //Products
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
			
			//Orders
			modelBuilder.Entity<Order>().ToTable("orders");
			modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
			modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("orderdate");
			modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("requireddate");
			modelBuilder.Entity<Order>().Property(x => x.Shipped).HasColumnName("shippeddate");
			modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
			modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
			modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");
			
			//OrderDetails
			modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
			modelBuilder.Entity<OrderDetails>().Property(x => x.OrderId).HasColumnName("orderid");
			modelBuilder.Entity<OrderDetails>().Property(x => x.ProductId).HasColumnName("productid");
			modelBuilder.Entity<OrderDetails>().Property(x => x.UnitPrice).HasColumnName("unitprice");
			modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("quantity");
			modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("discount");
			
		}

        //public static readonly LoggerFactory MyLoggerFactory
        //    = new LoggerFactory(new[]
        //    {
        //        new ConsoleLoggerProvider((category, level)
        //            => category == DbLoggerCategory.Database.Command.Name
        //               && level == LogLevel.Information, true)
        //    });
    }
}

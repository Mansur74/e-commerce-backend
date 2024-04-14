using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductRate> ProductRates { get; set; }
        public DbSet<ShopRate> ShopReviews { get; set; }
        public DbSet<ShopReview> ShopRates { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Carts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.Product)
                .WithMany(p => p.Wishlists)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Shipment)
                .WithMany(s => s.Orders)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithMany(u => u.Orders)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
               .HasOne(oi => oi.Product)
               .WithMany(p => p.OrderItems)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductRate>()
                .HasKey(pr => new { pr.UserId, pr.ProductId});

            modelBuilder.Entity<ProductRate>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.ProductRates)
                .HasForeignKey(pr => pr.UserId);

            modelBuilder.Entity<ProductRate>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.Rates)
                .HasForeignKey(pr => pr.ProductId);

            modelBuilder.Entity<ProductRate>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.Rates)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductReview>()
               .HasOne(pr => pr.User)
               .WithMany(u => u.ProductReviews)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductReview>()
               .HasOne(pr => pr.Rate)
               .WithMany(u => u.Reviews)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ShopRate>()
                .HasKey(sr => new { sr.UserId, sr.ShopId });

            modelBuilder.Entity<ShopRate>()
                .HasOne(sr => sr.User)
                .WithMany(u => u.ShopRates)
                .HasForeignKey(sr => sr.UserId);

            modelBuilder.Entity<ShopRate>()
                .HasOne(sr => sr.Shop)
                .WithMany(s => s.Rates)
                .HasForeignKey(sr => sr.ShopId);

            modelBuilder.Entity<ShopRate>()
                .HasOne(sr => sr.Shop)
                .WithMany(s => s.Rates)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShopReview>()
               .HasOne(sr => sr.User)
               .WithMany(u => u.ShopReviews)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShopReview>()
               .HasOne(sr => sr.Rate)
               .WithMany(u => u.Reviews)
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

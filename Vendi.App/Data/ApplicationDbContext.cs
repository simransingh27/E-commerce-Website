using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vendi.App.Models;
using Vendi.Data;

namespace Vendi.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        // public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        //   public DbSet<Role> Roles { get; set; }
       // public DbSet<Tag> Tags { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
      // public DbSet<MostViewedProduct> MostViewedProducts { get; set; }
        public DbSet<UserVisitedProduct> UserVisitedProducts { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
        public DbSet<FeaturedService> FeaturedServices { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Vendi.Data.Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<ServiceReview> ServiceReviews { get; set; }
        public DbSet<ServiceOffer> ServiceOffers { get; set; }
        public DbSet<ServiceFavorite> ServiceFavorites { get; set; }
        public DbSet<BusinessAddress> BusinessAddresses { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }



    }
}

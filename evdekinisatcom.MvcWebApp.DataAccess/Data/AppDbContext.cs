using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

namespace evdekinisatcom.MvcWebApp.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder
            //    .Entity<Product>()
            //    .HasOne(e => e.Seller)                       //ilişki tanımı, delete davranışı
            //    .WithMany(e => e.ProductsToSell)
            //    .OnDelete(DeleteBehavior.ClientCascade);

            //modelBuilder
            //    .Entity<Category>()
            //    .HasOne(c => c.ParentCategory)                       //ilişki tanımı
            //    .WithMany(c => c.subCategories)
            //    .HasForeignKey(c => c.ParentCategoryId);

            modelBuilder.Entity<AppUser>().Property(p => p.Balance).HasDefaultValue(0);
            modelBuilder.Entity<AppUser>().Property(p => p.ProfilePicUrl).HasDefaultValue("/userImages/defaultProfilePic.webp"); //default profil fotoğrafı

            modelBuilder.Entity<Category>().HasData(
    // Elektronik
    new Category { Id = 1, Name = "Elektronik" },
    new Category { Id = 2, Name = "Bilgisayarlar & Tabletler", ParentCategoryId = 1 },
    new Category { Id = 3, Name = "Telefonlar", ParentCategoryId = 1 },
    new Category { Id = 4, Name = "Oyun & Konsollar", ParentCategoryId = 1 },
    new Category { Id = 5, Name = "TV & Ses Sistemleri", ParentCategoryId = 1 },
    new Category { Id = 6, Name = "Kamera & Fotoğraf Makineleri", ParentCategoryId = 1 },

    // Giyim ve Aksesuar
    new Category { Id = 7, Name = "Giyim & Aksesuar" },
    new Category { Id = 8, Name = "Erkek Giyim", ParentCategoryId = 7 },
    new Category { Id = 9, Name = "Kadın Giyim", ParentCategoryId = 7 },
    new Category { Id = 10, Name = "Çocuk Giyim", ParentCategoryId = 7 },
    new Category { Id = 11, Name = "Ayakkabılar", ParentCategoryId = 7 },
    new Category { Id = 12, Name = "Çantalar", ParentCategoryId = 7 },

    // Ev ve Yaşam
    new Category { Id = 13, Name = "Ev & Yaşam" },
    new Category { Id = 14, Name = "Mobilya", ParentCategoryId = 13 },
    new Category { Id = 15, Name = "Dekorasyon", ParentCategoryId = 13 },
    new Category { Id = 16, Name = "Ev Aletleri", ParentCategoryId = 13 },

    // Kitap, Müzik ve Film
    new Category { Id = 17, Name = "Kitap & Müzik & Film" },
    new Category { Id = 18, Name = "Kitaplar", ParentCategoryId = 17 },
    new Category { Id = 19, Name = "Müzik Albümleri", ParentCategoryId = 17 },
    new Category { Id = 20, Name = "Filmler & Diziler", ParentCategoryId = 17 },

    // Spor ve Outdoor
    new Category { Id = 21, Name = "Spor & Outdoor" },
    new Category { Id = 22, Name = "Spor Giyim", ParentCategoryId = 21 },
    new Category { Id = 23, Name = "Spor Aletleri", ParentCategoryId = 21 },
    new Category { Id = 24, Name = "Kamp & Outdoor", ParentCategoryId = 21 },

    // Kozmetik ve Sağlık
    new Category { Id = 25, Name = "Kozmetik & Sağlık" },
    new Category { Id = 26, Name = "Makyaj", ParentCategoryId = 25 },
    new Category { Id = 27, Name = "Cilt Bakımı", ParentCategoryId = 25 },
    new Category { Id = 28, Name = "Saç Bakımı", ParentCategoryId = 25 },
    new Category { Id = 29, Name = "Parfümler", ParentCategoryId = 25 }
);
        }
    }
}

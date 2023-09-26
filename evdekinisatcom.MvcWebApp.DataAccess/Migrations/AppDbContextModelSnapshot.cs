﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using evdekinisatcom.MvcWebApp.DataAccess.Data;

#nullable disable

namespace evdekinisatcom.MvcWebApp.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("/userImages/defaultProfilePic.webp");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1167),
                            IsDeleted = false,
                            Name = "BaseCategory",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1179),
                            IsDeleted = false,
                            Name = "Elektronik",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1180),
                            IsDeleted = false,
                            Name = "Bilgisayarlar & Tabletler",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1181),
                            IsDeleted = false,
                            Name = "Telefonlar",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1182),
                            IsDeleted = false,
                            Name = "Oyun & Konsollar",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1183),
                            IsDeleted = false,
                            Name = "TV & Ses Sistemleri",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1184),
                            IsDeleted = false,
                            Name = "Kamera & Fotoğraf Makineleri",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1185),
                            IsDeleted = false,
                            Name = "Giyim & Aksesuar",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1186),
                            IsDeleted = false,
                            Name = "Erkek Giyim",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            Id = 10,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1186),
                            IsDeleted = false,
                            Name = "Kadın Giyim",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            Id = 11,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1187),
                            IsDeleted = false,
                            Name = "Çocuk Giyim",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            Id = 12,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1188),
                            IsDeleted = false,
                            Name = "Ayakkabılar",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            Id = 13,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1189),
                            IsDeleted = false,
                            Name = "Çantalar",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            Id = 14,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1190),
                            IsDeleted = false,
                            Name = "Ev & Yaşam",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 15,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1191),
                            IsDeleted = false,
                            Name = "Mobilya",
                            ParentCategoryId = 14
                        },
                        new
                        {
                            Id = 16,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1192),
                            IsDeleted = false,
                            Name = "Dekorasyon",
                            ParentCategoryId = 14
                        },
                        new
                        {
                            Id = 17,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1193),
                            IsDeleted = false,
                            Name = "Ev Aletleri",
                            ParentCategoryId = 14
                        },
                        new
                        {
                            Id = 18,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1194),
                            IsDeleted = false,
                            Name = "Kitap & Müzik & Film",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 19,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1195),
                            IsDeleted = false,
                            Name = "Kitaplar",
                            ParentCategoryId = 18
                        },
                        new
                        {
                            Id = 20,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1196),
                            IsDeleted = false,
                            Name = "Müzik Albümleri",
                            ParentCategoryId = 18
                        },
                        new
                        {
                            Id = 21,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1196),
                            IsDeleted = false,
                            Name = "Filmler & Diziler",
                            ParentCategoryId = 18
                        },
                        new
                        {
                            Id = 22,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1197),
                            IsDeleted = false,
                            Name = "Spor & Outdoor",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 23,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1198),
                            IsDeleted = false,
                            Name = "Spor Giyim",
                            ParentCategoryId = 22
                        },
                        new
                        {
                            Id = 24,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1199),
                            IsDeleted = false,
                            Name = "Spor Aletleri",
                            ParentCategoryId = 22
                        },
                        new
                        {
                            Id = 25,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1200),
                            IsDeleted = false,
                            Name = "Kamp & Outdoor",
                            ParentCategoryId = 22
                        },
                        new
                        {
                            Id = 26,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1201),
                            IsDeleted = false,
                            Name = "Kozmetik & Sağlık",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 27,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1202),
                            IsDeleted = false,
                            Name = "Makyaj",
                            ParentCategoryId = 26
                        },
                        new
                        {
                            Id = 28,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1203),
                            IsDeleted = false,
                            Name = "Cilt Bakımı",
                            ParentCategoryId = 26
                        },
                        new
                        {
                            Id = 29,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1204),
                            IsDeleted = false,
                            Name = "Saç Bakımı",
                            ParentCategoryId = 26
                        },
                        new
                        {
                            Id = 30,
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1205),
                            IsDeleted = false,
                            Name = "Parfümler",
                            ParentCategoryId = 26
                        });
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProducId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int?>("AppUserId1")
                        .HasColumnType("int");

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeaderImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AppUserId1");

                    b.HasIndex("CartId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Condition = "Yeni & Etiketli",
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1491),
                            Description = "Kutusu Açılmadı",
                            HeaderImageUrl = "C:\\projects\\evdekinisatcom.MvcWebApp\\evdekinisatcom.MvcWebApp.WebMvc\\wwwroot\\userUploads\\users\\ali\\137425-1_large.webp",
                            IsDeleted = false,
                            Price = 100m,
                            SellerId = 1,
                            Title = "Iphone 15"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Condition = "Az Kullanılmış",
                            CreatedDate = new DateTime(2023, 9, 26, 20, 57, 27, 291, DateTimeKind.Local).AddTicks(1494),
                            Description = "Sıfıra yakın",
                            HeaderImageUrl = "C:\\projects\\evdekinisatcom.MvcWebApp\\evdekinisatcom.MvcWebApp.WebMvc\\wwwroot\\userUploads\\users\\ali\\137425-1_large.webp",
                            IsDeleted = false,
                            Price = 150m,
                            SellerId = 1,
                            Title = "S23 Plus"
                        });
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.CartItem", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Category", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Category", "ParentCategory")
                        .WithMany("subCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Comment", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Order", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", null)
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.OrderDetail", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Product", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", null)
                        .WithMany("ProductsToSell")
                        .HasForeignKey("AppUserId");

                    b.HasOne("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", null)
                        .WithMany("PurchasedProducts")
                        .HasForeignKey("AppUserId1");

                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.ProductImage", b =>
                {
                    b.HasOne("evdekinisatcom.MvcWebApp_App.Entity.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp.DataAccess.Identity.Models.AppUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductsToSell");

                    b.Navigation("PurchasedProducts");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("subCategories");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("evdekinisatcom.MvcWebApp_App.Entity.Entities.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241114053154_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Model.CareSchedule", b =>
                {
                    b.Property<int>("CareScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareScheduleID"));

                    b.Property<int>("CareServiceID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlantID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CareScheduleID");

                    b.HasIndex("CareServiceID");

                    b.HasIndex("PlantID");

                    b.HasIndex("UserID");

                    b.ToTable("CareSchedules");
                });

            modelBuilder.Entity("BusinessObject.Model.CareService", b =>
                {
                    b.Property<int>("CareServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CareServiceID"));

                    b.Property<string>("CareServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CareServiceID");

                    b.ToTable("CareServices");

                    b.HasData(
                        new
                        {
                            CareServiceID = 1,
                            CareServiceName = "Standard"
                        },
                        new
                        {
                            CareServiceID = 2,
                            CareServiceName = "Advanced"
                        });
                });

            modelBuilder.Entity("BusinessObject.Model.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Indoor Plants",
                            Status = true
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Outdoor Plants",
                            Status = true
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Aquatic Plants",
                            Status = true
                        });
                });

            modelBuilder.Entity("BusinessObject.Model.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<DateTime?>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserOrderID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("UserOrderID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            DateOrder = new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 0m,
                            UserOrderID = 2
                        },
                        new
                        {
                            OrderID = 2,
                            DateOrder = new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 0m,
                            UserOrderID = 2
                        },
                        new
                        {
                            OrderID = 3,
                            DateOrder = new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 0m,
                            UserOrderID = 3
                        },
                        new
                        {
                            OrderID = 4,
                            DateOrder = new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 0m,
                            UserOrderID = 3
                        });
                });

            modelBuilder.Entity("BusinessObject.Model.OrderDetail", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("PlantID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "PlantID");

                    b.HasIndex("PlantID");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            PlantID = 1,
                            Price = 1500.00m,
                            Stock = 2
                        },
                        new
                        {
                            OrderID = 1,
                            PlantID = 2,
                            Price = 1200.00m,
                            Stock = 1
                        },
                        new
                        {
                            OrderID = 2,
                            PlantID = 3,
                            Price = 1100.00m,
                            Stock = 1
                        },
                        new
                        {
                            OrderID = 2,
                            PlantID = 4,
                            Price = 1300.00m,
                            Stock = 1
                        });
                });

            modelBuilder.Entity("BusinessObject.Model.Plant", b =>
                {
                    b.Property<int>("PlantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlantName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("PlantID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Plants");

                    b.HasData(
                        new
                        {
                            PlantID = 1,
                            CategoryID = 1,
                            Description = "Elegant plant with white blooms and dark green leaves, known for improving air quality.",
                            ImageUrl = "img/peace-lily.jpg",
                            PlantName = "Peace Lily",
                            Price = 21090000m,
                            Status = true,
                            Stock = 1000
                        },
                        new
                        {
                            PlantID = 2,
                            CategoryID = 2,
                            Description = "Fragrant herb with purple flowers, great for outdoor spaces and attracting pollinators.",
                            ImageUrl = "img/lavender .jpg",
                            PlantName = "Lavender",
                            Price = 27690000m,
                            Status = true,
                            Stock = 1000
                        },
                        new
                        {
                            PlantID = 3,
                            CategoryID = 3,
                            Description = "Easy-to-grow fern that thrives in aquariums, great for low-light conditions.",
                            ImageUrl = "img/java-fern.jpg",
                            PlantName = "Java Fern",
                            Price = 25490000m,
                            Status = true,
                            Stock = 1000
                        },
                        new
                        {
                            PlantID = 4,
                            CategoryID = 1,
                            Description = "A resilient, trailing plant that thrives in various indoor conditions and is easy to propagate.",
                            ImageUrl = "img/pothos.jpg",
                            PlantName = "Pothos",
                            Price = 37999000m,
                            Status = true,
                            Stock = 1000
                        });
                });

            modelBuilder.Entity("BusinessObject.Model.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin",
                            Status = true
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Customer",
                            Status = true
                        });
                });

            modelBuilder.Entity("BusinessObject.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Address = "Đà Nẵng, Việt Nam",
                            Email = "admin@",
                            Fullname = "Admin User",
                            Password = "123",
                            Phone = "1233211231",
                            RoleID = 1,
                            Status = true,
                            UserName = "admin"
                        },
                        new
                        {
                            UserID = 2,
                            Address = "Đà Nẵng, Việt Nam",
                            Email = "customer@",
                            Fullname = "Customer No1",
                            Password = "123",
                            Phone = "1233211231",
                            RoleID = 2,
                            Status = true,
                            UserName = "customer1"
                        },
                        new
                        {
                            UserID = 3,
                            Address = "Đà Nẵng, Việt Nam",
                            Email = "dung@",
                            Fullname = "Customer No2",
                            Password = "123",
                            Phone = "1234567890",
                            RoleID = 2,
                            Status = true,
                            UserName = "customer2"
                        });
                });

            modelBuilder.Entity("BusinessObject.Model.CareSchedule", b =>
                {
                    b.HasOne("BusinessObject.Model.CareService", "CareService")
                        .WithMany("CareSchedules")
                        .HasForeignKey("CareServiceID")
                        .IsRequired();

                    b.HasOne("BusinessObject.Model.Plant", "Plant")
                        .WithMany("CareSchedules")
                        .HasForeignKey("PlantID")
                        .IsRequired();

                    b.HasOne("BusinessObject.Model.User", "User")
                        .WithMany("CareSchedules")
                        .HasForeignKey("UserID")
                        .IsRequired();

                    b.Navigation("CareService");

                    b.Navigation("Plant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessObject.Model.Order", b =>
                {
                    b.HasOne("BusinessObject.Model.User", "UserOrder")
                        .WithMany("Orders")
                        .HasForeignKey("UserOrderID")
                        .IsRequired();

                    b.Navigation("UserOrder");
                });

            modelBuilder.Entity("BusinessObject.Model.OrderDetail", b =>
                {
                    b.HasOne("BusinessObject.Model.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .IsRequired();

                    b.HasOne("BusinessObject.Model.Plant", "Plant")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PlantID")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("BusinessObject.Model.Plant", b =>
                {
                    b.HasOne("BusinessObject.Model.Category", "Category")
                        .WithMany("Plants")
                        .HasForeignKey("CategoryID")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BusinessObject.Model.User", b =>
                {
                    b.HasOne("BusinessObject.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObject.Model.CareService", b =>
                {
                    b.Navigation("CareSchedules");
                });

            modelBuilder.Entity("BusinessObject.Model.Category", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("BusinessObject.Model.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BusinessObject.Model.Plant", b =>
                {
                    b.Navigation("CareSchedules");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BusinessObject.Model.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObject.Model.User", b =>
                {
                    b.Navigation("CareSchedules");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

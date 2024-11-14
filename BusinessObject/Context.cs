using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Context : DbContext
    {
        public Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Project_PRN212"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleID).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasOne(d => d.Category).WithMany(p => p.Plants)
                .HasForeignKey(d => d.CategoryID).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.UserOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserOrderID).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderID).OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Plant).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.PlantID).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CareSchedule>(entity =>
            {
                entity.HasOne(d => d.CareService).WithMany(p => p.CareSchedules)
                .HasForeignKey(d => d.CareServiceID).OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Plant).WithMany(p => p.CareSchedules)
                .HasForeignKey(d => d.PlantID).OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User).WithMany(p => p.CareSchedules)
                .HasForeignKey(d => d.UserID).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasData(
                    new Role
                    {
                        RoleID = 1,
                        RoleName = "Admin",
                        Status = true
                    },
                    new Role
                    {
                        RoleID = 2,
                        RoleName = "Customer",
                        Status = true
                    }
                );
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasData(
                    new User
                    {
                        UserID = 1,
                        Fullname = "Admin User",
                        UserName = "admin",
                        Password = "123",
                        Email = "admin@",
                        Phone = "1233211231",
                        Address = "Đà Nẵng, Việt Nam",
                        Status = true,
                        RoleID = 1
                    },
                    new User
                    {
                        UserID = 2,
                        Fullname = "Customer No1",
                        UserName = "customer1",
                        Password = "123",
                        Email = "customer@",
                        Phone = "1233211231",
                        Address = "Đà Nẵng, Việt Nam",
                        Status = true,
                        RoleID = 2
                    },
                    new User
                    {
                        UserID = 3,
                        Fullname = "Customer No2",
                        UserName = "customer2",
                        Password = "123",
                        Email = "dung@",
                        Phone = "1234567890",
                        Address = "Đà Nẵng, Việt Nam",
                        Status = true,
                        RoleID = 2
                    }
                );
            });
            
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasData(
                    new Order
                    {
                        OrderID = 1,
                        UserOrderID = 2,
                        DateOrder = new DateTime(2024, 11, 7),
                    },
                    new Order
                    {
                        OrderID = 2,
                        UserOrderID = 2,
                        DateOrder = new DateTime(2024, 11, 6),
                    },
                    new Order
                    {
                        OrderID = 3,
                        UserOrderID = 3,
                        DateOrder = new DateTime(2024, 11, 5),
                    },
                    new Order
                    {
                        OrderID = 4,
                        UserOrderID = 3,
                        DateOrder = new DateTime(2024, 11, 4),
                    }
                );
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasData(
                    new Category
                    {
                        CategoryID = 1,
                        CategoryName = "Indoor Plants",
                        Status = true
                    },
                    new Category
                    {
                        CategoryID = 2,
                        CategoryName = "Outdoor Plants",
                        Status = true,
                    },
                    new Category
                    {
                        CategoryID = 3,
                        CategoryName = "Aquatic Plants",
                        Status = true
                    });
            });
            
            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasData(
                    new Plant
                    {
                        PlantID = 1,
                        PlantName = "Peace Lily",
                        Description = "Elegant plant with white blooms and dark green leaves, known for improving air quality.",
                        Price = 21090000,
                        Stock = 1000,
                        ImageUrl = "img/peace-lily.jpg",
                        Status = true,
                        CategoryID = 1
                    },
                    new Plant
                    {
                        PlantID = 2,
                        PlantName = "Lavender",
                        Description = "Fragrant herb with purple flowers, great for outdoor spaces and attracting pollinators.",
                        Price = 27690000,
                        Stock = 1000,
                        ImageUrl = "img/lavender .jpg",
                        Status = true,
                        CategoryID = 2
                    },
                    new Plant
                    {
                        PlantID = 3,
                        PlantName = "Java Fern",
                        Description = "Easy-to-grow fern that thrives in aquariums, great for low-light conditions.",
                        Price = 25490000,
                        Stock = 1000,
                        ImageUrl = "img/java-fern.jpg",
                        Status = true,
                        CategoryID = 3
                    },
                    new Plant
                    {
                        PlantID = 4,
                        PlantName = "Pothos",
                        Description = "A resilient, trailing plant that thrives in various indoor conditions and is easy to propagate.",
                        Price = 37999000,
                        Stock = 1000,
                        ImageUrl = "img/pothos.jpg",
                        Status = true,
                        CategoryID = 1
                    }
                );
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasData(
                    new OrderDetail
                    {
                        OrderID = 1,
                        PlantID = 1, // Foreign key to Plants
                        Stock = 2,
                        Price = 1500.00M
                    },
                    new OrderDetail
                    {
                        OrderID = 1,
                        PlantID = 2, // Foreign key to Plants
                        Stock = 1,
                        Price = 1200.00M
                    },
                    new OrderDetail
                    {
                        OrderID = 2,
                        PlantID = 3, // Foreign key to Plants
                        Stock = 1,
                        Price = 1100.00M
                    },
                    new OrderDetail
                    {
                        OrderID = 2,
                        PlantID = 4, // Foreign key to Plants
                        Stock = 1,
                        Price = 1300.00M
                    }
                );
            });

            modelBuilder.Entity<CareService>(entity =>
            {
                entity.HasData(
                    new CareService
                    {
                        CareServiceID = 1,
                        CareServiceName = "Standard",
                    },
                    new CareService
                    {
                        CareServiceID = 2,
                        CareServiceName = "Advanced",
                    }
                );
            });
        }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<CareSchedule> CareSchedules { get; set; }
        public virtual DbSet<CareService> CareServices { get; set; }
    }
}

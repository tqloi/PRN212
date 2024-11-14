using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CareServices",
                columns: table => new
                {
                    CareServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareServices", x => x.CareServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantID);
                    table.ForeignKey(
                        name: "FK_Plants_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "CareSchedules",
                columns: table => new
                {
                    CareScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CareServiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareSchedules", x => x.CareScheduleID);
                    table.ForeignKey(
                        name: "FK_CareSchedules_CareServices_CareServiceID",
                        column: x => x.CareServiceID,
                        principalTable: "CareServices",
                        principalColumn: "CareServiceID");
                    table.ForeignKey(
                        name: "FK_CareSchedules_Plants_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plants",
                        principalColumn: "PlantID");
                    table.ForeignKey(
                        name: "FK_CareSchedules_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserOrderID = table.Column<int>(type: "int", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserOrderID",
                        column: x => x.UserOrderID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderID, x.PlantID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Plants_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plants",
                        principalColumn: "PlantID");
                });

            migrationBuilder.InsertData(
                table: "CareServices",
                columns: new[] { "CareServiceID", "CareServiceName" },
                values: new object[,]
                {
                    { 1, "Standard" },
                    { 2, "Advanced" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Status" },
                values: new object[,]
                {
                    { 1, "Indoor Plants", true },
                    { 2, "Outdoor Plants", true },
                    { 3, "Aquatic Plants", true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName", "Status" },
                values: new object[,]
                {
                    { 1, "Admin", true },
                    { 2, "Customer", true }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantID", "CategoryID", "Description", "ImageUrl", "PlantName", "Price", "Status", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Elegant plant with white blooms and dark green leaves, known for improving air quality.", "img/peace-lily.jpg", "Peace Lily", 21090000m, true, 1000 },
                    { 2, 2, "Fragrant herb with purple flowers, great for outdoor spaces and attracting pollinators.", "img/lavender .jpg", "Lavender", 27690000m, true, 1000 },
                    { 3, 3, "Easy-to-grow fern that thrives in aquariums, great for low-light conditions.", "img/java-fern.jpg", "Java Fern", 25490000m, true, 1000 },
                    { 4, 1, "A resilient, trailing plant that thrives in various indoor conditions and is easy to propagate.", "img/pothos.jpg", "Pothos", 37999000m, true, 1000 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "Email", "Fullname", "Password", "Phone", "RoleID", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "Đà Nẵng, Việt Nam", "admin@", "Admin User", "123", "1233211231", 1, true, "admin" },
                    { 2, "Đà Nẵng, Việt Nam", "customer@", "Customer No1", "123", "1233211231", 2, true, "customer1" },
                    { 3, "Đà Nẵng, Việt Nam", "dung@", "Customer No2", "123", "1234567890", 2, true, "customer2" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "DateOrder", "TotalPrice", "UserOrderID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 2 },
                    { 2, new DateTime(2024, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 2 },
                    { 3, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 3 },
                    { 4, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderID", "PlantID", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1500.00m, 2 },
                    { 1, 2, 1200.00m, 1 },
                    { 2, 3, 1100.00m, 1 },
                    { 2, 4, 1300.00m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareSchedules_CareServiceID",
                table: "CareSchedules",
                column: "CareServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_CareSchedules_PlantID",
                table: "CareSchedules",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_CareSchedules_UserID",
                table: "CareSchedules",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PlantID",
                table: "OrderDetails",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserOrderID",
                table: "Orders",
                column: "UserOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CategoryID",
                table: "Plants",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareSchedules");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "CareServices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareSchedules_Plants_PlantID",
                table: "CareSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_CareSchedules_Users_UserID",
                table: "CareSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_CareSchedules_Plants_PlantID",
                table: "CareSchedules",
                column: "PlantID",
                principalTable: "Plants",
                principalColumn: "PlantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CareSchedules_Users_UserID",
                table: "CareSchedules",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareSchedules_Plants_PlantID",
                table: "CareSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_CareSchedules_Users_UserID",
                table: "CareSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_CareSchedules_Plants_PlantID",
                table: "CareSchedules",
                column: "PlantID",
                principalTable: "Plants",
                principalColumn: "PlantID");

            migrationBuilder.AddForeignKey(
                name: "FK_CareSchedules_Users_UserID",
                table: "CareSchedules",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }
    }
}

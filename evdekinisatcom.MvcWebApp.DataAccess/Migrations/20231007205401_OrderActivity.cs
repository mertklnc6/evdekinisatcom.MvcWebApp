using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evdekinisatcom.MvcWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderActivities_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9602));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9603));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9611));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9615));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9617));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 54, 1, 121, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.CreateIndex(
                name: "IX_OrderActivities_OrderId",
                table: "OrderActivities",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderActivities");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 23, 48, 30, 112, DateTimeKind.Local).AddTicks(3011));
        }
    }
}

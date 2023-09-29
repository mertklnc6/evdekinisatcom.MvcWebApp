using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evdekinisatcom.MvcWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "ReturnUrl",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 29, 15, 3, 15, 456, DateTimeKind.Local).AddTicks(8749));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnUrl",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ProducId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 28, 17, 52, 21, 979, DateTimeKind.Local).AddTicks(2886));
        }
    }
}

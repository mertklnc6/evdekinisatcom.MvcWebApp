using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evdekinisatcom.MvcWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class boosted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBoosted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/images/default/defaultProfilePic.webp",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "/userImages/defaultProfilePic.webp");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3932));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3934));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsBoosted" },
                values: new object[] { new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(4284), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "IsBoosted" },
                values: new object[] { new DateTime(2023, 10, 12, 15, 50, 12, 161, DateTimeKind.Local).AddTicks(4288), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBoosted",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/userImages/defaultProfilePic.webp",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "/images/default/defaultProfilePic.webp");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 10, 1, 33, 376, DateTimeKind.Local).AddTicks(8533));
        }
    }
}

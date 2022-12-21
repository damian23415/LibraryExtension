using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryExtension.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRentDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 28, 11, 47, 25, 67, DateTimeKind.Utc).AddTicks(9458), new DateTime(2022, 12, 21, 11, 47, 25, 67, DateTimeKind.Utc).AddTicks(9457) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 24, 11, 47, 25, 67, DateTimeKind.Utc).AddTicks(9464), new DateTime(2022, 12, 21, 11, 47, 25, 67, DateTimeKind.Utc).AddTicks(9463) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2023, 1, 5, 11, 47, 25, 67, DateTimeKind.Utc).AddTicks(9465), new DateTime(2022, 12, 21, 11, 47, 25, 67, DateTimeKind.Utc).AddTicks(9464) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 28, 11, 45, 50, 983, DateTimeKind.Utc).AddTicks(3044), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 24, 11, 45, 50, 983, DateTimeKind.Utc).AddTicks(3049), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2023, 1, 5, 11, 45, 50, 983, DateTimeKind.Utc).AddTicks(3050), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

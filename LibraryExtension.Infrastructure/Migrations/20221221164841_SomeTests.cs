using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryExtension.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SomeTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 28, 16, 48, 41, 11, DateTimeKind.Utc).AddTicks(3734), new DateTime(2022, 12, 21, 16, 48, 41, 11, DateTimeKind.Utc).AddTicks(3733) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 24, 16, 48, 41, 11, DateTimeKind.Utc).AddTicks(3740), new DateTime(2022, 12, 21, 16, 48, 41, 11, DateTimeKind.Utc).AddTicks(3740) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2023, 1, 5, 16, 48, 41, 11, DateTimeKind.Utc).AddTicks(3741), new DateTime(2022, 12, 21, 16, 48, 41, 11, DateTimeKind.Utc).AddTicks(3741) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 28, 16, 43, 18, 423, DateTimeKind.Utc).AddTicks(8779), new DateTime(2022, 12, 21, 16, 43, 18, 423, DateTimeKind.Utc).AddTicks(8778) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2022, 12, 24, 16, 43, 18, 423, DateTimeKind.Utc).AddTicks(8784), new DateTime(2022, 12, 21, 16, 43, 18, 423, DateTimeKind.Utc).AddTicks(8783) });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpectedReturnDate", "RentDate" },
                values: new object[] { new DateTime(2023, 1, 5, 16, 43, 18, 423, DateTimeKind.Utc).AddTicks(8785), new DateTime(2022, 12, 21, 16, 43, 18, 423, DateTimeKind.Utc).AddTicks(8784) });
        }
    }
}

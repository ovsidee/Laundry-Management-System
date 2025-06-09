using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2.Migrations
{
    /// <inheritdoc />
    public partial class dataChangedABit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Vitalii", "Korytnyi" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Michal", "Pazio" });

            migrationBuilder.UpdateData(
                table: "Purchase_History",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 1, 2 },
                column: "PurchaseDate",
                value: new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Washing_Machine",
                keyColumn: "WashingMachineId",
                keyValue: 1,
                column: "SerialNumber",
                value: "TK/6662/31");

            migrationBuilder.UpdateData(
                table: "Washing_Machine",
                keyColumn: "WashingMachineId",
                keyValue: 2,
                column: "SerialNumber",
                value: "TN/6102/52");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Hello", "World" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Hello", "World" });

            migrationBuilder.UpdateData(
                table: "Purchase_History",
                keyColumns: new[] { "AvailableProgramId", "CustomerId" },
                keyValues: new object[] { 1, 2 },
                column: "PurchaseDate",
                value: new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Washing_Machine",
                keyColumn: "WashingMachineId",
                keyValue: 1,
                column: "SerialNumber",
                value: "someNumber123");

            migrationBuilder.UpdateData(
                table: "Washing_Machine",
                keyColumn: "WashingMachineId",
                keyValue: 2,
                column: "SerialNumber",
                value: "anotherNumber456");
        }
    }
}

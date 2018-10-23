using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeApproval.Migrations
{
    public partial class AlterSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "UnitSets");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "UnitSets");

            migrationBuilder.DropColumn(
                name: "SubmittedAt",
                table: "UnitSets");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "StudentApplications");

            migrationBuilder.DropColumn(
                name: "ExchangeDate",
                table: "StudentApplications");

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "siD36VF+8Kbt7QnBd6iwNuWLZLjb0GUfgRAxLP2lNc8=", new byte[] { 25, 219, 44, 17, 72, 57, 55, 150, 4, 103, 114, 160, 215, 255, 235, 232 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "UnitSets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "UnitSets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedAt",
                table: "UnitSets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "StudentApplications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExchangeDate",
                table: "StudentApplications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "InAdOAPwcGKRUuWmechPgSW7oKTL9rdL7YwnZWl8HP0=", new byte[] { 228, 229, 226, 199, 166, 209, 206, 69, 214, 2, 152, 38, 135, 211, 129, 129 } });
        }
    }
}

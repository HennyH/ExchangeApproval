using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeApproval.Migrations
{
    public partial class UpdateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "StudentApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentOffice",
                table: "StudentApplications",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "eMY4QLz+XrN/Fcanvr6KrjRoGxDlvljeq04a/O94ZAw=", new byte[] { 114, 152, 81, 149, 18, 46, 245, 81, 176, 144, 215, 248, 214, 135, 232, 201 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "StudentApplications");

            migrationBuilder.DropColumn(
                name: "StudentOffice",
                table: "StudentApplications");

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "siD36VF+8Kbt7QnBd6iwNuWLZLjb0GUfgRAxLP2lNc8=", new byte[] { 25, 219, 44, 17, 72, 57, 55, 150, 4, 103, 114, 160, 215, 255, 235, 232 } });
        }
    }
}

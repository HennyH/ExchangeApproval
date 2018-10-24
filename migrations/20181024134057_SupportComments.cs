using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeApproval.Migrations
{
    public partial class SupportComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "StudentApplications");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "UnitSets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "R8U/8tx1LwqJwQZfmsx+xnjjyyUrlUCDu5jt1EAVbh0=", new byte[] { 156, 102, 190, 114, 114, 244, 119, 247, 140, 252, 60, 197, 255, 134, 205, 181 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "UnitSets");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "StudentApplications",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "YL/Z1doeub21aTP9otLKlXIy2oDIQW6abpqE9H0rmjU=", new byte[] { 76, 145, 232, 148, 83, 198, 180, 185, 99, 38, 111, 223, 60, 48, 215, 26 } });
        }
    }
}

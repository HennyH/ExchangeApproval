using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeApproval.Migrations
{
    public partial class AddStatusToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StudentApplications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "YL/Z1doeub21aTP9otLKlXIy2oDIQW6abpqE9H0rmjU=", new byte[] { 76, 145, 232, 148, 83, 198, 180, 185, 99, 38, 111, 223, 60, 48, 215, 26 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentApplications");

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "fOqFsoq+hSQrVN2MBSVbpB3JV7pZ/C4wb18Vv3c8SWw=", new byte[] { 101, 82, 68, 2, 116, 22, 37, 160, 111, 223, 89, 11, 63, 183, 156, 20 } });
        }
    }
}

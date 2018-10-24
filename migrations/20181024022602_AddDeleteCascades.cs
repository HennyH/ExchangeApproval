using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeApproval.Migrations
{
    public partial class AddDeleteCascades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeUnits_UnitSets_UnitSetId",
                table: "ExchangeUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_UWAUnits_UnitSets_UnitSetId",
                table: "UWAUnits");

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "fOqFsoq+hSQrVN2MBSVbpB3JV7pZ/C4wb18Vv3c8SWw=", new byte[] { 101, 82, 68, 2, 116, 22, 37, 160, 111, 223, 89, 11, 63, 183, 156, 20 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeUnits_UnitSets_UnitSetId",
                table: "ExchangeUnits",
                column: "UnitSetId",
                principalTable: "UnitSets",
                principalColumn: "UnitSetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UWAUnits_UnitSets_UnitSetId",
                table: "UWAUnits",
                column: "UnitSetId",
                principalTable: "UnitSets",
                principalColumn: "UnitSetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeUnits_UnitSets_UnitSetId",
                table: "ExchangeUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_UWAUnits_UnitSets_UnitSetId",
                table: "UWAUnits");

            migrationBuilder.UpdateData(
                table: "StaffLogons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "Salt" },
                values: new object[] { "eMY4QLz+XrN/Fcanvr6KrjRoGxDlvljeq04a/O94ZAw=", new byte[] { 114, 152, 81, 149, 18, 46, 245, 81, 176, 144, 215, 248, 214, 135, 232, 201 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeUnits_UnitSets_UnitSetId",
                table: "ExchangeUnits",
                column: "UnitSetId",
                principalTable: "UnitSets",
                principalColumn: "UnitSetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UWAUnits_UnitSets_UnitSetId",
                table: "UWAUnits",
                column: "UnitSetId",
                principalTable: "UnitSets",
                principalColumn: "UnitSetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

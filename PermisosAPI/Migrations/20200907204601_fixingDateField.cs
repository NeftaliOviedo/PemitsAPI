using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermisosAPI.Migrations
{
    public partial class fixingDateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaPermiso",
                table: "Permit");

            migrationBuilder.AddColumn<DateTime>(
                name: "PermitDate",
                table: "Permit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermitDate",
                table: "Permit");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPermiso",
                table: "Permit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

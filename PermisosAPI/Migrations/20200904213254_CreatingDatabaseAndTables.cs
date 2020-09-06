using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermisosAPI.Migrations
{
    public partial class CreatingDatabaseAndTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: false),
                    EmployeeLastname = table.Column<string>(nullable: false),
                    PermitTypeId = table.Column<int>(nullable: false),
                    FechaPermiso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permit_PermitType_PermitTypeId",
                        column: x => x.PermitTypeId,
                        principalTable: "PermitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permit_PermitTypeId",
                table: "Permit",
                column: "PermitTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permit");

            migrationBuilder.DropTable(
                name: "PermitType");
        }
    }
}

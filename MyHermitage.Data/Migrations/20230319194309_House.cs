using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHermitage.Data.Migrations
{
    public partial class House : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Architecture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfBuilding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    NumberOfStoreys = table.Column<int>(type: "int", nullable: false),
                    BildingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBildingPermition = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "House");
        }
    }
}

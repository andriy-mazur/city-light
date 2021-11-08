using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityLight.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Areas", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPerson = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Customers", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Citylights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<int>(type: "INTEGER", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Longitude = table.Column<decimal>(type: "TEXT", nullable: false),
                    Side1 = table.Column<string>(type: "TEXT", nullable: true),
                    Side1Photo = table.Column<string>(type: "TEXT", nullable: true),
                    Side2 = table.Column<string>(type: "TEXT", nullable: true),
                    Side2Photo = table.Column<string>(type: "TEXT", nullable: true),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citylights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citylights_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citylights_AreaId",
                table: "Citylights",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citylights");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}

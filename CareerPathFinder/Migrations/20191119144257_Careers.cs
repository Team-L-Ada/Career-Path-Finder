using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPathFinder.Migrations
{
    public partial class Careers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CareerId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Career",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Career", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CareerId",
                table: "Categories",
                column: "CareerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Career_CareerId",
                table: "Categories",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Career_CareerId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Career");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CareerId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CareerId",
                table: "Categories");
        }
    }
}

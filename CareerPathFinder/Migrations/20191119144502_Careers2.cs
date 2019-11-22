using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerPathFinder.Migrations
{
    public partial class Careers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Career_CareerId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Career",
                table: "Career");

            migrationBuilder.RenameTable(
                name: "Career",
                newName: "Careers");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Careers",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Careers",
                table: "Careers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Careers_CareerId",
                table: "Categories",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Careers_CareerId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Careers",
                table: "Careers");

            migrationBuilder.RenameTable(
                name: "Careers",
                newName: "Career");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Career",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Career",
                table: "Career",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Career_CareerId",
                table: "Categories",
                column: "CareerId",
                principalTable: "Career",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

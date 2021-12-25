using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicDiary.DAL.Migrations
{
    public partial class AddTimeLabeltoRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WasCreated",
                table: "Record",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WasDeleted",
                table: "Record",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WasModifyed",
                table: "Record",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WasCreated",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "WasDeleted",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "WasModifyed",
                table: "Record");
        }
    }
}

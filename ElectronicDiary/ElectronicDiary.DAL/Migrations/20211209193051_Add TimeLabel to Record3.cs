using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicDiary.DAL.Migrations
{
    public partial class AddTimeLabeltoRecord3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeLabel",
                columns: table => new
                {
                    WasCreated = table.Column<DateTime>(nullable: true),
                    WasModifyed = table.Column<DateTime>(nullable: true),
                    WasDeleted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeLabel");
        }
    }
}

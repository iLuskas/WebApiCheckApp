using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class alterAnoFabricacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano_fabricacao",
                table: "Extintor");

            migrationBuilder.AddColumn<string>(
                name: "AnoFabricacao_ext",
                table: "Extintor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoFabricacao_ext",
                table: "Extintor");

            migrationBuilder.AddColumn<DateTime>(
                name: "Ano_fabricacao",
                table: "Extintor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

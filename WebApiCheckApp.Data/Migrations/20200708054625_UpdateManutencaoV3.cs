using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class UpdateManutencaoV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Capacidade",
                table: "Manutencao",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinal",
                table: "Manutencao",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicial",
                table: "Manutencao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duracao",
                table: "Manutencao",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFinal",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "DataInicial",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "Duracao",
                table: "Manutencao");

            migrationBuilder.AlterColumn<double>(
                name: "Capacidade",
                table: "Manutencao",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}

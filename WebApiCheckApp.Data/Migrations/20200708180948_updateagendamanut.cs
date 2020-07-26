using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class updateagendamanut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Norma",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "NumExt",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "NumPatrimonio",
                table: "Manutencao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimoTeste",
                table: "Manutencao",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRecarga",
                table: "Manutencao",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataReteste",
                table: "Manutencao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumCilindro",
                table: "Manutencao",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OcorrenciaInspecao",
                table: "AgendaInspManut",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TipoManutencao",
                table: "AgendaInspManut",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRecarga",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "DataReteste",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "NumCilindro",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "OcorrenciaInspecao",
                table: "AgendaInspManut");

            migrationBuilder.DropColumn(
                name: "TipoManutencao",
                table: "AgendaInspManut");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimoTeste",
                table: "Manutencao",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Norma",
                table: "Manutencao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumExt",
                table: "Manutencao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumPatrimonio",
                table: "Manutencao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}

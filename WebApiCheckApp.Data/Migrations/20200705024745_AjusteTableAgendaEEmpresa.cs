using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class AjusteTableAgendaEEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Inspecao",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "Inspecao",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EmpresaCliente",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinal",
                table: "AgendaInspManut",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duracao",
                table: "AgendaInspManut",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Email",
                table: "EmpresaCliente");

            migrationBuilder.DropColumn(
                name: "DataFinal",
                table: "AgendaInspManut");

            migrationBuilder.DropColumn(
                name: "Duracao",
                table: "AgendaInspManut");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicial",
                table: "Inspecao",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "Inspecao",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}

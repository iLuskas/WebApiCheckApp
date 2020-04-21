using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class ajustetelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEmpresa_Cliente",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Telefone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpresa_Cliente",
                table: "Telefone",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Telefone",
                type: "int",
                nullable: true);
        }
    }
}

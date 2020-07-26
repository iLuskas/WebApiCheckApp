using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class ajusteEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspecao_Equipamento_Seguranca_EquipamentoSegurancaId",
                table: "Inspecao");

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoSegurancaId",
                table: "Inspecao",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inspecao_Equipamento_Seguranca_EquipamentoSegurancaId",
                table: "Inspecao",
                column: "EquipamentoSegurancaId",
                principalTable: "Equipamento_Seguranca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspecao_Equipamento_Seguranca_EquipamentoSegurancaId",
                table: "Inspecao");

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoSegurancaId",
                table: "Inspecao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Inspecao_Equipamento_Seguranca_EquipamentoSegurancaId",
                table: "Inspecao",
                column: "EquipamentoSegurancaId",
                principalTable: "Equipamento_Seguranca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

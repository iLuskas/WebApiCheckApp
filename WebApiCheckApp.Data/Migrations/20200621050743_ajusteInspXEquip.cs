using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class ajusteInspXEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentoInspecao");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoSegurancaId",
                table: "Inspecao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_EquipamentoSegurancaId",
                table: "Inspecao",
                column: "EquipamentoSegurancaId");

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

            migrationBuilder.DropIndex(
                name: "IX_Inspecao_EquipamentoSegurancaId",
                table: "Inspecao");

            migrationBuilder.DropColumn(
                name: "EquipamentoSegurancaId",
                table: "Inspecao");

            migrationBuilder.CreateTable(
                name: "EquipamentoInspecao",
                columns: table => new
                {
                    InspecaoId = table.Column<int>(type: "int", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoInspecao", x => new { x.InspecaoId, x.EquipamentoId });
                    table.ForeignKey(
                        name: "FK_EquipamentoInspecao_Equipamento_Seguranca_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento_Seguranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipamentoInspecao_Inspecao_InspecaoId",
                        column: x => x.InspecaoId,
                        principalTable: "Inspecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoInspecao_EquipamentoId",
                table: "EquipamentoInspecao",
                column: "EquipamentoId");
        }
    }
}

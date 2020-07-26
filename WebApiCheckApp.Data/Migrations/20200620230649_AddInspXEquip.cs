using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class AddInspXEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspecao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusInspManutId = table.Column<int>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    EmpresaClienteId = table.Column<int>(nullable: false),
                    AgendaInspManutId = table.Column<int>(nullable: true),
                    UtilmaRec_Insp = table.Column<string>(maxLength: 50, nullable: true),
                    ProximoRec_Insp = table.Column<string>(maxLength: 50, nullable: true),
                    UltimoReteste_Insp = table.Column<string>(maxLength: 50, nullable: true),
                    ProximoReteste_Insp = table.Column<string>(maxLength: 50, nullable: true),
                    EstadoCilindro_Insp = table.Column<string>(maxLength: 20, nullable: true),
                    EstadoLocal_Insp = table.Column<string>(maxLength: 20, nullable: true),
                    SeloLacre_insp = table.Column<string>(maxLength: 20, nullable: true),
                    SinalizacaoPiso_insp = table.Column<string>(maxLength: 20, nullable: true),
                    SinalizacaoAcesso_insp = table.Column<string>(maxLength: 20, nullable: true),
                    Obs_Insp = table.Column<string>(maxLength: 255, nullable: true),
                    DataInicial = table.Column<DateTime>(nullable: true),
                    DataFinal = table.Column<DateTime>(nullable: true),
                    Duracao = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspecao_AgendaInspManut_AgendaInspManutId",
                        column: x => x.AgendaInspManutId,
                        principalTable: "AgendaInspManut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspecao_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspecao_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspecao_StatusInspManut_StatusInspManutId",
                        column: x => x.StatusInspManutId,
                        principalTable: "StatusInspManut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoInspecao",
                columns: table => new
                {
                    InspecaoId = table.Column<int>(nullable: false),
                    EquipamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoInspecao", x => new { x.InspecaoId, x.EquipamentoId });
                    table.ForeignKey(
                        name: "FK_EquipamentoInspecao_Equipamento_Seguranca_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento_Seguranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipamentoInspecao_Inspecao_InspecaoId",
                        column: x => x.InspecaoId,
                        principalTable: "Inspecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoInspecao_EquipamentoId",
                table: "EquipamentoInspecao",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_AgendaInspManutId",
                table: "Inspecao",
                column: "AgendaInspManutId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_EmpresaClienteId",
                table: "Inspecao",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_FuncionarioId",
                table: "Inspecao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecao_StatusInspManutId",
                table: "Inspecao",
                column: "StatusInspManutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipamentoInspecao");

            migrationBuilder.DropTable(
                name: "Inspecao");
        }
    }
}

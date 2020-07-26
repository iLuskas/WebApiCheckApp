using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class AddAgendaInspManut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusInspManut",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusAgenda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInspManut", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAgendamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAgenda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAgendamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgendaInspManut",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(nullable: false),
                    EmpresaClienteId = table.Column<int>(nullable: false),
                    TipoEquipamentoId = table.Column<int>(nullable: false),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    TipoAgendamentoId = table.Column<int>(nullable: false),
                    StatusInspManutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaInspManut", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaInspManut_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgendaInspManut_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgendaInspManut_StatusInspManut_StatusInspManutId",
                        column: x => x.StatusInspManutId,
                        principalTable: "StatusInspManut",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgendaInspManut_TipoAgendamento_TipoAgendamentoId",
                        column: x => x.TipoAgendamentoId,
                        principalTable: "TipoAgendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgendaInspManut_Tipo_equipamento_TipoEquipamentoId",
                        column: x => x.TipoEquipamentoId,
                        principalTable: "Tipo_equipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "StatusInspManut",
                columns: new[] { "Id", "statusAgenda" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Em Andamento" },
                    { 3, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "TipoAgendamento",
                columns: new[] { "Id", "TipoAgenda" },
                values: new object[,]
                {
                    { 1, "Inspeção" },
                    { 2, "Manutenção" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaInspManut_EmpresaClienteId",
                table: "AgendaInspManut",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaInspManut_FuncionarioId",
                table: "AgendaInspManut",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaInspManut_StatusInspManutId",
                table: "AgendaInspManut",
                column: "StatusInspManutId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaInspManut_TipoAgendamentoId",
                table: "AgendaInspManut",
                column: "TipoAgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaInspManut_TipoEquipamentoId",
                table: "AgendaInspManut",
                column: "TipoEquipamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaInspManut");

            migrationBuilder.DropTable(
                name: "StatusInspManut");

            migrationBuilder.DropTable(
                name: "TipoAgendamento");
        }
    }
}

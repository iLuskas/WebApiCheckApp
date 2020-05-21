using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class addEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipo_equipamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_equipamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento_Seguranca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_equipamentoId = table.Column<int>(nullable: false),
                    EmpresaClienteId = table.Column<int>(nullable: false),
                    Localizacao_equipamento = table.Column<string>(nullable: true),
                    QrCode = table.Column<string>(nullable: true),
                    Qrcode_data_geracao = table.Column<DateTime>(nullable: false),
                    DataCriacao_equipamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento_Seguranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamento_Seguranca_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamento_Seguranca_Tipo_equipamento_Tipo_equipamentoId",
                        column: x => x.Tipo_equipamentoId,
                        principalTable: "Tipo_equipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Extintor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipamentoId = table.Column<int>(nullable: false),
                    Num_ext = table.Column<int>(nullable: false),
                    SeloInmetro_ext = table.Column<string>(nullable: true),
                    Fabricante_ext = table.Column<string>(nullable: true),
                    Tipo_ext = table.Column<string>(nullable: true),
                    Peso_ext = table.Column<double>(nullable: false),
                    Capacidade_ext = table.Column<double>(nullable: false),
                    Ano_fabricacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extintor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extintor_Equipamento_Seguranca_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento_Seguranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_Seguranca_EmpresaClienteId",
                table: "Equipamento_Seguranca",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_Seguranca_Tipo_equipamentoId",
                table: "Equipamento_Seguranca",
                column: "Tipo_equipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Extintor_EquipamentoId",
                table: "Extintor",
                column: "EquipamentoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extintor");

            migrationBuilder.DropTable(
                name: "Equipamento_Seguranca");

            migrationBuilder.DropTable(
                name: "Tipo_equipamento");
        }
    }
}

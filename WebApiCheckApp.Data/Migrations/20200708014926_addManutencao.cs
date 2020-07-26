using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class addManutencao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoExt = table.Column<string>(maxLength: 20, nullable: true),
                    Capacidade = table.Column<double>(nullable: false),
                    AnoFabricacao = table.Column<string>(maxLength: 4, nullable: true),
                    FabricanteExt = table.Column<string>(maxLength: 50, nullable: true),
                    Norma = table.Column<string>(maxLength: 50, nullable: true),
                    UltimoTeste = table.Column<DateTime>(nullable: false),
                    NumPatrimonio = table.Column<string>(maxLength: 50, nullable: true),
                    NumExt = table.Column<string>(maxLength: 50, nullable: true),
                    SeloInmetro = table.Column<string>(maxLength: 50, nullable: true),
                    ObsManut = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AltaPressaoNv3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManutencaoId = table.Column<int>(nullable: false),
                    PressaoTrabalho = table.Column<string>(nullable: true),
                    PressaoTeste = table.Column<string>(nullable: true),
                    Tara = table.Column<string>(nullable: true),
                    Massa = table.Column<string>(nullable: true),
                    VolumeLitro = table.Column<string>(nullable: true),
                    CapMaxCarga = table.Column<string>(nullable: true),
                    EE = table.Column<string>(nullable: true),
                    ET = table.Column<string>(nullable: true),
                    EP = table.Column<string>(nullable: true),
                    EP_ET = table.Column<string>(nullable: true),
                    AprovadoCondenado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltaPressaoNv3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltaPressaoNv3_Manutencao_ManutencaoId",
                        column: x => x.ManutencaoId,
                        principalTable: "Manutencao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaixaPressaoNv3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManutencaoId = table.Column<int>(nullable: false),
                    PressaoTrabalho = table.Column<string>(nullable: true),
                    PressaoTeste = table.Column<string>(nullable: true),
                    AprovadoCondenado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaixaPressaoNv3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaixaPressaoNv3_Manutencao_ManutencaoId",
                        column: x => x.ManutencaoId,
                        principalTable: "Manutencao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltaPressaoNv3_ManutencaoId",
                table: "AltaPressaoNv3",
                column: "ManutencaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaixaPressaoNv3_ManutencaoId",
                table: "BaixaPressaoNv3",
                column: "ManutencaoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltaPressaoNv3");

            migrationBuilder.DropTable(
                name: "BaixaPressaoNv3");

            migrationBuilder.DropTable(
                name: "Manutencao");
        }
    }
}

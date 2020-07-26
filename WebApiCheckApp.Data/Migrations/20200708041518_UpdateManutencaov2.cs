using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class UpdateManutencaov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltaPressaoNv3");

            migrationBuilder.DropTable(
                name: "BaixaPressaoNv3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AltaPressaoNv3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AprovadoCondenado = table.Column<bool>(type: "bit", nullable: false),
                    CapMaxCarga = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EP_ET = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ET = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManutencaoId = table.Column<int>(type: "int", nullable: false),
                    Massa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PressaoTeste = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PressaoTrabalho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tara = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VolumeLitro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AprovadoCondenado = table.Column<bool>(type: "bit", nullable: false),
                    ManutencaoId = table.Column<int>(type: "int", nullable: false),
                    PressaoTeste = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PressaoTrabalho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
    }
}

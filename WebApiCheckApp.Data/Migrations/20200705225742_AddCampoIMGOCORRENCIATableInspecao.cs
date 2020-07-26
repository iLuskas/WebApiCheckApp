using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class AddCampoIMGOCORRENCIATableInspecao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "precisaManutencao",
                table: "Inspecao",
                newName: "PrecisaManutencao");

            migrationBuilder.AlterColumn<bool>(
                name: "PrecisaManutencao",
                table: "Inspecao",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "ImagemOcorrencia",
                table: "Inspecao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemOcorrencia",
                table: "Inspecao");

            migrationBuilder.RenameColumn(
                name: "PrecisaManutencao",
                table: "Inspecao",
                newName: "precisaManutencao");

            migrationBuilder.AlterColumn<bool>(
                name: "precisaManutencao",
                table: "Inspecao",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}

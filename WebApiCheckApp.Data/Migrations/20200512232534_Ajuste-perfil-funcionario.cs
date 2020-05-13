using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class Ajusteperfilfuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Funcionario_FuncionarioId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Perfil_PerfilId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Funcionario_FuncionarioId",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "idPerfil",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "Funcao_perfil",
                table: "Perfil",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PerfilId",
                table: "Funcionario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionario",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Funcionario",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Funcionario_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Perfil_PerfilId",
                table: "Funcionario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Usuario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Funcionario_FuncionarioId",
                table: "Telefone",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Funcionario_FuncionarioId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Perfil_PerfilId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Usuario_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Funcionario_FuncionarioId",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "Funcao_perfil",
                table: "Perfil",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PerfilId",
                table: "Funcionario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idPerfil",
                table: "Funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Funcionario_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Perfil_PerfilId",
                table: "Funcionario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Funcionario_FuncionarioId",
                table: "Telefone",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class UpdateManutencao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendaInspManutId",
                table: "Manutencao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaClienteId",
                table: "Manutencao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoSegurancaId",
                table: "Manutencao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Manutencao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusInspManutId",
                table: "Manutencao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTrabalho",
                table: "BaixaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTeste",
                table: "BaixaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VolumeLitro",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tara",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTrabalho",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTeste",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Massa",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ET",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EP_ET",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EP",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EE",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CapMaxCarga",
                table: "AltaPressaoNv3",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_AgendaInspManutId",
                table: "Manutencao",
                column: "AgendaInspManutId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_EmpresaClienteId",
                table: "Manutencao",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_EquipamentoSegurancaId",
                table: "Manutencao",
                column: "EquipamentoSegurancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_FuncionarioId",
                table: "Manutencao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_StatusInspManutId",
                table: "Manutencao",
                column: "StatusInspManutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_AgendaInspManut_AgendaInspManutId",
                table: "Manutencao",
                column: "AgendaInspManutId",
                principalTable: "AgendaInspManut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_EmpresaCliente_EmpresaClienteId",
                table: "Manutencao",
                column: "EmpresaClienteId",
                principalTable: "EmpresaCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_Equipamento_Seguranca_EquipamentoSegurancaId",
                table: "Manutencao",
                column: "EquipamentoSegurancaId",
                principalTable: "Equipamento_Seguranca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_Funcionario_FuncionarioId",
                table: "Manutencao",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_StatusInspManut_StatusInspManutId",
                table: "Manutencao",
                column: "StatusInspManutId",
                principalTable: "StatusInspManut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_AgendaInspManut_AgendaInspManutId",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_EmpresaCliente_EmpresaClienteId",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_Equipamento_Seguranca_EquipamentoSegurancaId",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_Funcionario_FuncionarioId",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_StatusInspManut_StatusInspManutId",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_AgendaInspManutId",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_EmpresaClienteId",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_EquipamentoSegurancaId",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_FuncionarioId",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_StatusInspManutId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "AgendaInspManutId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "EmpresaClienteId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "EquipamentoSegurancaId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "StatusInspManutId",
                table: "Manutencao");

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTrabalho",
                table: "BaixaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTeste",
                table: "BaixaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VolumeLitro",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tara",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTrabalho",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PressaoTeste",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Massa",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ET",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EP_ET",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EP",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EE",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CapMaxCarga",
                table: "AltaPressaoNv3",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}

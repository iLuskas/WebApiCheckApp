﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresaCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(maxLength: 255, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    Inscricao_estadual = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Funcao_perfil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(nullable: true),
                    EmpresaClienteId = table.Column<int>(nullable: true),
                    Pais_end = table.Column<string>(maxLength: 50, nullable: true),
                    Estado_end = table.Column<string>(maxLength: 50, nullable: true),
                    Cidade_end = table.Column<string>(maxLength: 50, nullable: true),
                    Bairro_end = table.Column<string>(maxLength: 50, nullable: true),
                    Rua_end = table.Column<string>(maxLength: 50, nullable: true),
                    Numero_end = table.Column<string>(maxLength: 10, nullable: true),
                    Cep_end = table.Column<string>(maxLength: 8, nullable: true),
                    Tipo_end = table.Column<string>(maxLength: 20, nullable: true),
                    Status_end = table.Column<int>(nullable: false),
                    Percentual_end = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPerfil = table.Column<int>(nullable: false),
                    PerfilId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true),
                    IdEmpresa_Cliente = table.Column<int>(nullable: true),
                    EmpresaClienteId = table.Column<int>(nullable: true),
                    ddd_tel = table.Column<string>(nullable: true),
                    Telefone_tel = table.Column<string>(nullable: true),
                    Tipo_tel = table.Column<string>(nullable: true),
                    Status_tel = table.Column<int>(nullable: false),
                    Percentual_tel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefone_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EmpresaClienteId",
                table: "Endereco",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PerfilId",
                table: "Funcionario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_EmpresaClienteId",
                table: "Telefone",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_FuncionarioId",
                table: "Telefone",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "EmpresaCliente");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}

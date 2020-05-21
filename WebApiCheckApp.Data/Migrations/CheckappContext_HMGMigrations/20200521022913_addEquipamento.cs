﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCheckApp.Infrastruture.Data.Migrations.CheckappContext_HMGMigrations
{
    public partial class addEquipamento : Migration
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
                    Funcao_perfil = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

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
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 200, nullable: true),
                    Cpf = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Funcionario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
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
                    Cep_end = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endereco_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(nullable: true),
                    EmpresaClienteId = table.Column<int>(nullable: true),
                    ddd_tel = table.Column<string>(maxLength: 3, nullable: true),
                    Telefone_tel = table.Column<string>(maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_EmpresaCliente_EmpresaClienteId",
                        column: x => x.EmpresaClienteId,
                        principalTable: "EmpresaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Telefone_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EmpresaClienteId",
                table: "Endereco",
                column: "EmpresaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_FuncionarioId",
                table: "Endereco",
                column: "FuncionarioId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PerfilId",
                table: "Funcionario",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_UsuarioId",
                table: "Funcionario",
                column: "UsuarioId",
                unique: true,
                filter: "[UsuarioId] IS NOT NULL");

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
                name: "Extintor");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Equipamento_Seguranca");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "EmpresaCliente");

            migrationBuilder.DropTable(
                name: "Tipo_equipamento");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

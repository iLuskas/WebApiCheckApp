﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiCheckApp.Data;

namespace WebApiCheckApp.Infrastruture.Data.Migrations
{
    [DbContext(typeof(CheckappContext))]
    [Migration("20200421013021_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.EmpresaCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Inscricao_estadual")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("EmpresaCliente");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro_end")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Cep_end")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade_end")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("EmpresaClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Estado_end")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Numero_end")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Pais_end")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Percentual_end")
                        .HasColumnType("int");

                    b.Property<string>("Rua_end")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Status_end")
                        .HasColumnType("int");

                    b.Property<string>("Tipo_end")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerfilId")
                        .HasColumnType("int");

                    b.Property<int>("idPerfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Funcao_perfil")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmpresaClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int?>("IdEmpresa_Cliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("Percentual_tel")
                        .HasColumnType("int");

                    b.Property<int>("Status_tel")
                        .HasColumnType("int");

                    b.Property<string>("Telefone_tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_tel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ddd_tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Endereco", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.EmpresaCliente", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("EmpresaClienteId");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Funcionario", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Telefone", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.EmpresaCliente", "EmpresaCliente")
                        .WithMany("Telefones")
                        .HasForeignKey("EmpresaClienteId");

                    b.HasOne("WebApiCheckApp.Domain.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");
                });
#pragma warning restore 612, 618
        }
    }
}

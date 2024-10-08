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
    [Migration("20200616004351_AddAgendaInspManut")]
    partial class AddAgendaInspManut
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.AgendaInspManut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaClienteId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("StatusInspManutId")
                        .HasColumnType("int");

                    b.Property<int>("TipoAgendamentoId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEquipamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaClienteId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("StatusInspManutId");

                    b.HasIndex("TipoAgendamentoId");

                    b.HasIndex("TipoEquipamentoId");

                    b.ToTable("AgendaInspManut");
                });

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

                    b.Property<string>("Rua_end")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Equipamento_Seguranca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao_equipamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao_equipamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QrCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Qrcode_data_geracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Tipo_equipamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaClienteId");

                    b.HasIndex("Tipo_equipamentoId");

                    b.ToTable("Equipamento_Seguranca");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Extintor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnoFabricacao_ext")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<double>("Capacidade_ext")
                        .HasColumnType("float");

                    b.Property<int>("EquipamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Fabricante_ext")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Num_ext")
                        .HasColumnType("int");

                    b.Property<string>("SeloInmetro_ext")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Tipo_ext")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("EquipamentoId")
                        .IsUnique();

                    b.ToTable("Extintor");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("[UsuarioId] IS NOT NULL");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Funcao_perfil")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.StatusInspManut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("statusAgenda")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusInspManut");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            statusAgenda = "Pendente"
                        },
                        new
                        {
                            Id = 2,
                            statusAgenda = "Em Andamento"
                        },
                        new
                        {
                            Id = 3,
                            statusAgenda = "Finalizado"
                        });
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

                    b.Property<string>("Telefone_tel")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("ddd_tel")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.TipoAgendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoAgenda")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoAgendamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TipoAgenda = "Inspeção"
                        },
                        new
                        {
                            Id = 2,
                            TipoAgenda = "Manutenção"
                        });
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Tipo_equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tipo_equipamento");
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

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.AgendaInspManut", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.EmpresaCliente", "EmpresaCliente")
                        .WithMany()
                        .HasForeignKey("EmpresaClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCheckApp.Domain.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCheckApp.Domain.Models.StatusInspManut", "StatusInspManut")
                        .WithMany()
                        .HasForeignKey("StatusInspManutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCheckApp.Domain.Models.TipoAgendamento", "TipoAgendamento")
                        .WithMany()
                        .HasForeignKey("TipoAgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCheckApp.Domain.Models.Tipo_equipamento", "TipoEquipamento")
                        .WithMany()
                        .HasForeignKey("TipoEquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Endereco", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.EmpresaCliente", "EmpresaCliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("EmpresaClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCheckApp.Domain.Models.Funcionario", "Funcionario")
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Equipamento_Seguranca", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.EmpresaCliente", "EmpresaCliente")
                        .WithMany("Equipamentos")
                        .HasForeignKey("EmpresaClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCheckApp.Domain.Models.Tipo_equipamento", "Tipo")
                        .WithMany()
                        .HasForeignKey("Tipo_equipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Extintor", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.Equipamento_Seguranca", "Equipamento")
                        .WithOne("Extintor")
                        .HasForeignKey("WebApiCheckApp.Domain.Models.Extintor", "EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Funcionario", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiCheckApp.Domain.Models.Usuario", "Usuario")
                        .WithOne("Funcionario")
                        .HasForeignKey("WebApiCheckApp.Domain.Models.Funcionario", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiCheckApp.Domain.Models.Telefone", b =>
                {
                    b.HasOne("WebApiCheckApp.Domain.Models.EmpresaCliente", "EmpresaCliente")
                        .WithMany("Telefones")
                        .HasForeignKey("EmpresaClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiCheckApp.Domain.Models.Funcionario", "Funcionario")
                        .WithMany("Telefones")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

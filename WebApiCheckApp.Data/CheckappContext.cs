using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Data
{
    public class CheckappContext : DbContext
    {
        public CheckappContext() { }

        public CheckappContext(DbContextOptions<CheckappContext> options) : base(options)
        {

        }

        public IDbContextTransaction Transaction { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<EmpresaCliente> EmpresaClientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Equipamento_Seguranca> Equipamento_Segurancas { get; set; }        
        public DbSet<Extintor> Extintors { get; set; }
        public DbSet<TipoAgendamento> TipoAgendamentos { get; set; }
        public DbSet<AgendaInspManut> AgendaInspManuts { get; set; }
        public DbSet<StatusInspManut> StatusInspManuts { get; set; }
        public DbSet<Inspecao> Inspecoes { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null)
                Transaction = this.Database.BeginTransaction();

            return Transaction;
        }


        private void RollBack()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            modelBuilder.Entity<Usuario>().HasOne(t => t.Funcionario)
                .WithOne(t => t.Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmpresaCliente>().ToTable("EmpresaCliente")
                .HasMany(e => e.Enderecos).WithOne(e => e.EmpresaCliente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmpresaCliente>().HasMany(e => e.Telefones)
                .WithOne(e => e.EmpresaCliente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmpresaCliente>().HasMany(e => e.Equipamentos)
                .WithOne(e => e.EmpresaCliente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Telefone>().ToTable("Telefone");
            modelBuilder.Entity<Perfil>().ToTable("Perfil");

            modelBuilder.Entity<Funcionario>().ToTable("Funcionario")
                .HasMany(e => e.Enderecos).WithOne(e => e.Funcionario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Funcionario>().HasMany(t => t.Telefones)
                .WithOne(t => t.Funcionario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Equipamento_Seguranca>().ToTable("Equipamento_Seguranca")
                .HasOne(e => e.Extintor).WithOne(eq => eq.Equipamento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Equipamento_Seguranca>()
                .HasMany(e => e.Inspecoes).WithOne(i => i.EquipamentoSeguranca);

            modelBuilder.Entity<Extintor>().ToTable("Extintor");

            modelBuilder.Entity<TipoAgendamento>().ToTable("TipoAgendamento")
                .HasData(new List<TipoAgendamento>() {
                    new TipoAgendamento(){Id=1,TipoAgenda="Inspeção"},
                    new TipoAgendamento(){Id=2,TipoAgenda="Manutenção"},
                });

            modelBuilder.Entity<StatusInspManut>().ToTable("StatusInspManut")
                .HasData(new List<StatusInspManut>() {
                    new StatusInspManut(){Id=1,statusAgenda="Pendente"},
                    new StatusInspManut(){Id=2,statusAgenda="Em Andamento"},
                    new StatusInspManut(){Id=3,statusAgenda="Finalizado"},
                 });

            modelBuilder.Entity<AgendaInspManut>().ToTable("AgendaInspManut")
                .HasMany(a => a.Inspecoes)
                .WithOne(t => t.AgendaInspManut);

            modelBuilder.Entity<Inspecao>().ToTable("Inspecao");
            modelBuilder.Entity<Manutencao>().ToTable("Manutencao");

            base.OnModelCreating(modelBuilder);
        }
    }
}

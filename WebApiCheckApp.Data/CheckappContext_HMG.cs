using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Data
{
    public class CheckappContext_HMG : DbContext
    {
        public CheckappContext_HMG() { }

        public CheckappContext_HMG(DbContextOptions<CheckappContext_HMG> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LAPTOP-3VUFSI4U\\SQLEXPRESS;initial catalog=checkApp;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            base.OnConfiguring(optionsBuilder);
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

            modelBuilder.Entity<Extintor>().ToTable("Extintor");

            base.OnModelCreating(modelBuilder);
        }
    }
}

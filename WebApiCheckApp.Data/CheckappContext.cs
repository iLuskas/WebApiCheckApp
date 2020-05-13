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

            modelBuilder.Entity<EmpresaCliente>().ToTable("EmpresaCliente")
                .HasMany(e => e.Enderecos).WithOne(e => e.EmpresaCliente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmpresaCliente>().HasMany(e => e.Telefones)
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

            modelBuilder.Entity<Funcionario>().HasOne(t => t.Usuario)
                .WithOne(t => t.Funcionario)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

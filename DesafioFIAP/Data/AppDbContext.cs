using DesafioFIAP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DesafioFIAP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AlunoModel> Aluno { get; set; } = null!;
        public DbSet<TurmaModel> Turma { get; set; } = null!;
        public DbSet<MatriculaModel> Matricula { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlunoModel>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TurmaModel>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MatriculaModel>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
        }
    }
}

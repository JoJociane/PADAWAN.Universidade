using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Context
{
     public class BDUniversidadeContext : DbContext
    {
        public BDUniversidadeContext() 
        {

        }

        public BDUniversidadeContext(DbContextOptions<BDUniversidadeContext> options) :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=NT-04837\\SQLEXPRESS; Initial Catalog=TesteBD; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BDUniversidadeContext).Assembly);

            //apenas dos relacionamentos?
            modelBuilder.Entity<MateriaCurso>().HasOne(q => q.Materia).WithMany(q => q.MateriaCurso).HasForeignKey(q => q.IdMateria);
            modelBuilder.Entity<MateriaCurso>().HasOne(q => q.Curso).WithMany(q => q.MateriaCurso).HasForeignKey(q => q.IdCurso);
            modelBuilder.Entity<Notas>().HasOne(q => q.Materia).WithMany(q => q.Nota).HasForeignKey(q => q.IdMateria);
            modelBuilder.Entity<Notas>().HasOne(q => q.Aluno).WithMany(q => q.Nota).HasForeignKey(q => q.IdAluno);

        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<Notas> Notas { get; set; }

        public DbSet<MateriaCurso> MateriaCurso { get; set; }
    }
}

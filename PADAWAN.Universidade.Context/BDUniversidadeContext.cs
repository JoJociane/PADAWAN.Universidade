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
            optionsBuilder.UseSqlServer("Data Source=NT-04837\\SQLEXPRESS; Initial Catalog=TesteBD; Integrated Security=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BDUniversidadeContext).Assembly);
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Materia> Materias { get; set; }


        public DbSet<Notas> Notas { get; set; }
    }
}

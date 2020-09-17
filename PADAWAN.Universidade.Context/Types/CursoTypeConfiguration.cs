using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Context.Types
{
    public class CursoTypeConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Nome).HasMaxLength(100).IsRequired();
            builder.Property(q => q.SituacaoCurso).HasMaxLength(100).IsRequired();

            builder.HasMany(q => q.Materias).WithOne().HasForeignKey(q => q.IdCurso);
            builder.HasMany(q => q.Alunos).WithOne().HasForeignKey(q => q.IdCurso);


        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Context.Types
{
    public class AlunoTypeConfiguration : IEntityTypeConfiguration<Aluno>
    {
         public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Nome).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Sobrenome).HasMaxLength(100).IsRequired();
            builder.Property(q => q.DataNascimento).IsRequired();
            builder.Property(q => q.CPF).HasMaxLength(16).IsRequired();

            //aluno-curso 1:n
            //builder.HasOne(q => q.Curso).WithMany().HasForeignKey(q => q.IdCurso);
        }
    }
}

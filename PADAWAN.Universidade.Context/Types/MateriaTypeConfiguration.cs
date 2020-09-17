using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Context.Types
{
    public class MateriaTypeConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(q => q.DataCadastro).IsRequired();
            builder.Property(q => q.SituacaoMateria).HasMaxLength(100).IsRequired();
            
            builder.HasOne(q => q.Curso).WithMany().HasForeignKey(q => q.IdCurso);
        }
    }
}

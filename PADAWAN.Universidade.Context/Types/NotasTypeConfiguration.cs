using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Context.Types
{
    public class NotasTypeConfiguration : IEntityTypeConfiguration<Notas>
    {
        public void Configure(EntityTypeBuilder<Notas> builder)
        {
            builder.HasKey(q => q.IdNota);
            builder.HasKey(q => q.IdAluno);
            builder.HasKey(q => q.IdMateria);

            builder.Property(q => q.ValorNota).IsRequired();
            

           //builder.HasOne(q => q.Materia).WithMany().HasForeignKey(q => q.IdMateria);
           //builder.HasOne(q => q.Aluno).WithMany().HasForeignKey(q => q.IdAluno);

        }
    }
}

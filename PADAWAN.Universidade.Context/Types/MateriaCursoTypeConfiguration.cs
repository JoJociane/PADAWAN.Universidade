using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Context.Types
{
    public class MateriaCursoTypeConfiguration : IEntityTypeConfiguration<MateriaCurso>
    {
        public void Configure(EntityTypeBuilder<MateriaCurso> builder)
        {
            builder.HasOne(q => q.Materia).WithMany().HasForeignKey(q => q.IdMateria);
            builder.HasOne(q => q.Curso).WithMany().HasForeignKey(q => q.IdCurso);

        }
    }
}

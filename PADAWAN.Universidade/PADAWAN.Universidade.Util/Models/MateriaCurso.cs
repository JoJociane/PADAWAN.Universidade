using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class MateriaCurso
    {
        
        public int IdMateria { get; set; }

        public virtual Materia Materia { get; set; }

        public int IdCurso { get; set; }

        public virtual Curso Curso { get; set; }

    }
}

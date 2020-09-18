using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class MateriaCurso
    {
        public int IdMateria { get; set; }

        public Materia Materia { get; set; }


        public int IdCurso { get; set; }

        public Curso Curso { get; set; }

    }
}

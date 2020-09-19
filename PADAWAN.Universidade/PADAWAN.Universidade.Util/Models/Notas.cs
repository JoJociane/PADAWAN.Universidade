using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class Notas
    {
       
      
        public int IdAluno { get; set; }

        public int IdMateria { get; set; }

        public double ValorNota { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Materia Materia { get; set; }


    }
}

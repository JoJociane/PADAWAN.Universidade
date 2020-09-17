using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Materia> Materias { get; set; } = new HashSet<Materia>();

        public ICollection<Aluno> Alunos { get; set; } = new HashSet<Aluno>();

        public string SituacaoCurso { get; set; }


    }
}

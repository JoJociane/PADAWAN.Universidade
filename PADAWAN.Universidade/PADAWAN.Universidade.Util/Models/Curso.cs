using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class Curso
    {
        public int Id { get; }
        public string Nome { get; set; }
        public string SituacaoCurso { get; set; }
        public virtual ICollection<MateriaCurso> MateriaCurso { get; set; } = new List<MateriaCurso>();
        public virtual ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}


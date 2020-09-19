using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class Curso
    {
        public int Id { get;  }
        public string Nome { get; set; }

        public ICollection<MateriaCurso> MateriaCurso { get; set; } = new List<MateriaCurso>();

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public string SituacaoCurso { get; set; }
     
        }
    }


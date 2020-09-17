using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }

        public string SituacaoMateria { get; set; }

        public int IdCurso { get; set; }

        public virtual Curso Curso { get; set; }

    }
}

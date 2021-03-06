﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PADAWAN.Universidade.Util.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public ICollection<Notas> Nota { get; set; } = new List<Notas>();

        
    }
}

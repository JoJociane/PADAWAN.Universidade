using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Util.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Materia> Materias { get; set; } = new List<Materia>();

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public string SituacaoCurso { get; set; }


        public bool Adiciona(Curso curso)
        {
            RetornaCurso(curso.Nome);

            if (!retorno)
            {
                listaCurso.Add(curso);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Curso RetornaCurso(string nome)
        {
            return  listaCurso.Where(q => q.Nome == nome).Any();
        }


        public bool BuscaCurso(string curso)
        {
            try
            {
                var result = listaCurso.Where(x => x.Nome.Contains(curso)).ToList();
                if (result.Count == 0)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using PADAWAN.Universidade.Context;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PADAWAN.Universidade.Context
{
    public class Tools<T>
    {
        private BDUniversidadeContext conexao;

        public bool Adiciona(Curso curso)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                //verifica primeiro se o curso ja existe na Tabela Cursos
                var retorno = RetornaCurso(curso.Nome);

                if (!retorno)//nao tenho, logo add
                {
                    conexao.Cursos.Add(curso);
                    conexao.SaveChanges();
                    return true;
                }
                else//ja consta no bd
                {
                    return false;
                }
            }
        }

        public bool RetornaCurso(string nome)
        {   
            //se a tabela Cursos tiver ALGUM curso com o mesmo nome passado ele retorna TRUE, 
            //senao FALSE (ou seja, nao existe entao posso add no banco)
            return conexao.Cursos.Where(q => q.Nome == nome).Any();
        }

        
        public bool BuscaCurso(string curso)
        {
            try
            {
                var result = conexao.Cursos.Where(x => x.Nome.Contains(curso)).ToList();
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

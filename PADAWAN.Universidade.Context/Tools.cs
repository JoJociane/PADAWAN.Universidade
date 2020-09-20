using PADAWAN.Universidade.Context;
using PADAWAN.Universidade.Util;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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

        public List<Curso> FindCurso(string curso, out bool temcurso)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                //busca no banco na Tabela Curso, 
                //try
                var result = conexao.Cursos.Where(x => x.Nome.Contains(curso)).ToList();
                if (result.Count == 0)//nao encontrou
                {
                    temcurso = false;
                    return result;
                }
                else
                {
                    temcurso = true;
                    return result;
                }
                //catch (Exception ex)
            }
        }

        public bool DeleteCurso(string curso)
        {
            bool removeu;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Cursos.Where(x => x.Nome.Contains(curso)).ToList();
                if(result.Count == 0)//nao encontrou o curso p remover
                {
                    return removeu = false;
                }
                else
                {
                    conexao.Cursos.Remove(result.FirstOrDefault());
                    conexao.SaveChanges();
                    removeu = true;
                    return removeu;
                }
                
            }
        }

        public bool UpdateCurso(int IDcurso, string novocurso)
        {
            bool atualizou;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Cursos.Where(x => x.Id == IDcurso).ToList();
                if(result.Count == 0)
                {
                    return atualizou = false;
                }
                else
                {
                    var meucursinho = result.FirstOrDefault();
                    // var newcurso = meucursinho;//copio objetos
                    //newcurso.Nome = novocurso;//seto nome novo obj

                    meucursinho.Nome = novocurso;
                    atualizou = true;
                    // conexao.Cursos.Add(newcurso);//add no banco
                    conexao.SaveChanges();
                    return atualizou;
                   // conexao.Cursos.Remove(meucursinho);//excluo anterior
                    
                    
                }
            }
        }




        public bool Adiciona(Aluno aluno)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                //verifica primeiro se o Aluno ja existe na Tabela Alunos
                var retorno = conexao.Alunos.Where(q => q.CPF == aluno.CPF).Any();

                if (!retorno)//nao tenho, logo add
                {
                    conexao.Alunos.Add(aluno);
                    conexao.SaveChanges();
                    return true;
                }
                else//ja consta no bd
                {
                    return false;
                }
            }
        }

        public List<Aluno> FindAluno(string nome, out bool encontrou)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                //busca no banco na Tabela Alunos, 
                //try
                var result = conexao.Alunos.Where(x => x.Nome.Contains(nome)).ToList();
                if (result.Count == 0)//nao encontrou
                {
                    encontrou = false;
                    return result;
                }
                else
                {
                    encontrou = true;
                    return result;
                }
                //catch (Exception ex)
            }
        }

        public bool DeleteAluno(string nome, string sobrenome)
        {
            bool removeu;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Alunos.Where(x => x.Nome.Contains(nome) && x.Sobrenome.Contains(sobrenome)).ToList();
                if (result.Count == 0)//nao encontrou o aluno p remover
                {
                    return removeu = false;
                }
                else
                {
                    conexao.Alunos.Remove(result.FirstOrDefault());
                    conexao.SaveChanges();
                    removeu = true;
                    return removeu;
                }

            }//Deletar em cascada? 
        }

        public bool UpdateAluno(int IDaluno, string novonome)
        {
            bool atualizou;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Alunos.Where(x => x.Id == IDaluno).ToList();
                if (result.Count == 0)
                {
                    return atualizou = false;
                }
                else
                {
                    var aluninho = result.FirstOrDefault();
                    aluninho.Nome = novonome;
                    atualizou = true;
                    conexao.SaveChanges();
                    return atualizou;

                }
            }
        }



    }
}

﻿using Microsoft.AspNetCore.Mvc;
using PADAWAN.Universidade.Context;
using PADAWAN.Universidade.Util;
using PADAWAN.Universidade.Util.ErrosMensagem;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace PADAWAN.Universidade.Context.Operacoes
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
                var retorno = conexao.Cursos.Where(q => q.Nome == curso.Nome).Any();
                //se a tabela Cursos tiver ALGUM curso com o mesmo nome passado ele retorna TRUE, 
                //senao FALSE (ou seja, nao existe entao posso add no banco)

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
                if (result.Count == 0)//nao encontrou o curso p remover
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

        public bool UpdateCurso(int IDcurso, string novocurso, string status)
        {
            bool atualizou;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Cursos.Where(x => x.Id == IDcurso).ToList();
                if (result.Count == 0)
                {
                    return atualizou = false;
                }
                else
                {
                    var meucursinho = result.FirstOrDefault();
                    // var newcurso = meucursinho;//copio objetos
                    //newcurso.Nome = novocurso;//seto nome novo obj

                    meucursinho.Nome = novocurso;
                    meucursinho.SituacaoCurso = status;
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
                string limpo = Regex.Replace(aluno.CPF, @"\D", ""); //limpa caracteres do cpf
                aluno.CPF = limpo;

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



        public bool Adiciona(Materia materia)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {

                var retorno = conexao.Materias.Where(q => q.Descricao == materia.Descricao).Any();


                if (!retorno)//nao tenho, logo add
                {
                    conexao.Materias.Add(materia);
                    conexao.SaveChanges();
                    return true;
                }
                else//ja consta no bd
                {
                    return false;
                }
            }
        }

        public List<Materia> FindMateria(string materia, out bool encontrou)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                //busca no banco na Tabela Alunos, 
                //try
                var result = conexao.Materias.Where(x => x.Descricao.Contains(materia)).ToList();
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

        public bool DeleteMateria(string materia)
        {
            bool removeu;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Materias.Where(x => x.Descricao.Contains(materia)).ToList();

                if (result.Count == 0)//nao encontrou o materias p remover
                {
                    return removeu = false;
                }
                else
                {
                    conexao.Materias.Remove(result.FirstOrDefault());
                    conexao.SaveChanges();
                    removeu = true;
                    return removeu;
                }

            }//Deletar em cascada? 
        }

        public bool UpdateMateria(int IDmateria, string novonome, string status)
        {
            bool atualizou;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Materias.Where(x => x.Id == IDmateria).ToList();
                if (result.Count == 0)
                {
                    return atualizou = false;
                }
                else
                {
                    var mat = result.FirstOrDefault();
                    mat.Descricao = novonome;
                    mat.SituacaoMateria = status;
                    atualizou = true;
                    conexao.SaveChanges();
                    return atualizou;

                }
            }
        }




        public bool Adiciona(Notas nota)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                //preciso verificar se aquela ID materia já esta relacionada com a minha ID Aluno
                var retorno = conexao.Notas.Where(q => q.IdAluno.Equals(nota.IdAluno) && q.IdMateria.Equals(nota.IdMateria)).Any();
                bool ver = false;
                if (!retorno)//nao tenho, logo add
                {
                    conexao.Notas.Add(nota);
                    ver = true;
                    conexao.SaveChanges();

                }
                else//ja consta no bd
                {
                    ver = false;
                }

                return ver;


            }
        }

        public List<Notas> FindNota(int IdAluno, out bool encontrou)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var result = conexao.Notas.Where(x => x.IdAluno.Equals(IdAluno)).ToList();
                //se encontrou gostaria que mostrasse o nome do aluno as materias e suas respectivas notas 

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

            }
        }

        public bool DeleteNotas(int IdAluno, int IdMateria)
        {
            bool removeu;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {

                var retorno = conexao.Notas.Where(q => q.IdAluno.Equals(IdAluno) && q.IdMateria.Equals(IdMateria)).ToList();

                if (retorno.Count == 0)//nao encontrou o materias p remover
                {
                    return removeu = false;
                }
                else
                {
                    conexao.Notas.Remove(retorno.FirstOrDefault());
                    conexao.SaveChanges();
                    removeu = true;
                    return removeu;
                }

            }//Deletar em cascada? 
        }

        public bool UpdateNota(int IdAluno, int IdMateria, double valor)
        {
            bool atualizou;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {

                var retorno = conexao.Notas.Where(q => q.IdAluno.Equals(IdAluno) && q.IdMateria.Equals(IdMateria)).ToList();

                if (retorno.Count == 0)
                {
                    return atualizou = false;
                }
                else
                {
                    var not = retorno.FirstOrDefault();
                    not.ValorNota = valor;
                    atualizou = true;
                    conexao.SaveChanges();
                    return atualizou;

                }
            }
        }



        public bool Adiciona(int IdMateria, int IdCurso)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                //preciso verificar se aquela ID materia já esta relacionada com a minha ID Curso
                var retorno = conexao.MateriaCurso.Where(q => q.IdMateria.Equals(IdMateria) && q.IdCurso.Equals(IdCurso)).Any();

                if (!retorno)//nao tenho, logo add
                {
                    var rel = new MateriaCurso();
                    rel.IdMateria = IdMateria;
                    rel.IdCurso = IdCurso;
                    conexao.MateriaCurso.Add(rel);
                    conexao.SaveChanges();
                    return true;
                }
                else//ja consta no bd
                {
                    return false;
                }
            }
        }
        public List<MateriaCurso> FindMateria(int Idmateria, out bool achou)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                // ver se o Id da materia passado tem alguma relacao com algum id curso
                var result = conexao.MateriaCurso.Where(x => x.IdMateria.Equals(Idmateria)).ToList();
                if (result.Count == 0)//nao encontrou
                {
                    achou = false;
                    return result;
                }
                else
                {
                    achou = true;
                    return result;
                }
            }
        }
        public bool DeleteMC(int IdMateria, int IdCurso)
        {
            bool removeu;
            conexao = new BDUniversidadeContext();
            using (conexao)
            {

                var retorno = conexao.MateriaCurso.Where(q => q.IdMateria.Equals(IdMateria) && q.IdCurso.Equals(IdCurso)).ToList();

                if (retorno.Count == 0)//nao encontrou o materias p remover
                {
                    return removeu = false;
                }
                else
                {
                    conexao.MateriaCurso.Remove(retorno.FirstOrDefault());
                    conexao.SaveChanges();
                    removeu = true;
                    return removeu;
                }

            }//Deletar em cascada? 
        }




        public List<Aluno> AllAlunos()
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var alunos = conexao.Alunos.Select(q => q).ToList();
                return alunos;
            }
        }

        public List<Curso> AllCursos()
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var c = conexao.Cursos.Select(q => q).ToList();
                return c;
            }
        }

        public List<Materia> AllMaterias()
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var m = conexao.Materias.Select(q => q).ToList();
                return m;
            }
        }

        public List<Notas> AllNotas()
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var n = conexao.Notas.Select(q => q).ToList();
                return n;
            }
        }

        public List<MateriaCurso> AllMC()
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var mc = conexao.MateriaCurso.Select(q => q).ToList();
                return mc;
            }
        }



        public bool VerificaCurso(int IdCurso)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                var cursosativos = conexao.Cursos.Where(q => q.SituacaoCurso.Equals("Ativo")).ToList();
                bool achou = false;
                foreach (var curso in cursosativos)
                {
                    if (curso.Id == IdCurso) { achou = true; }
                }
                return achou;
            }
        }

        public bool VerificaMateriaAluno(int IdMateria, int Idaluno)
        {
            conexao = new BDUniversidadeContext();
            using (conexao)
            {
                // a materia deve estar cadastrada, ativa e estar relacionada com curso
                // var materiasCadastradaEAtiva = conexao.Materias.Where(q => q.SituacaoMateria.Equals("Ativa") && q.Id == IdMateria).FirstOrDefault();

                //para estar em materiacurso, tem que estar ativa

                //pesquiso a materia, que esta relacionada com o curso
                var materiaEstaEmCurso = conexao.MateriaCurso.Where(q => q.IdMateria.Equals(IdMateria)).ToList();
                var aux = materiaEstaEmCurso.FirstOrDefault(); //se exite eu pego este materia curso
                //agora vejo se o id curso que está nela é o mesmo do aluno
                var aux1 = conexao.Alunos.Where(q => q.CursoId == aux.IdCurso).ToList();

                foreach (var aluno in aux1)
                {
                    if (aluno.Id == Idaluno) { return true; }
                }
                return false;

            }
        }
        

    }

   
}

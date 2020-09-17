using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PADAWAN.Universidade.Util;
using PADAWAN.Universidade.Util.Models;

namespace PADAWAN.Universidade.Controllers
{
    [ApiController]
    [Route("CadastroAluno")]
    public class AlunoController : ControllerBase
    {

        public static List<Aluno> listaAlunos = new List<Aluno>(); //aparentemente esta lista é meu banco

        [HttpGet]
        [Route("GetAluno")]
        public ActionResult GetAluno()//ok
        {
            var aluno = new Aluno()//inserir para verificar, vou popular minha tabela no sql
            {
                Nome = "Joaozinho",
                Sobrenome = "da Silva",
                DataNascimento = new DateTime(1997, 12, 24),
                CPF = "796.655.920-33",
                IdCurso=1
            };

            return Ok(aluno);
        }

        [HttpPost]
        [Route("PostAluno")]
        public ActionResult PostAluno(Aluno aluno)//ok
        {
            listaAlunos.Add(aluno);
            return Ok(listaAlunos);
        }

        [HttpGet]
        [Route("BuscaAluno")]
        public ActionResult GetAluno(string nome, string sobrenome, DateTime data)//ok
        {
            try
            {
                var result = listaAlunos.Where(x => x.Nome.Contains(nome)).ToList();
                if (result.Count == 0)
                {
                    return BadRequest(Message.Failure);
                }
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(Message.Failure + "----" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAluno")]
        public ActionResult DeleteAluno(string nome, string sobrenome)
        {
            try//pq pra deletar eu uso o nome e sobrenome// ou aqui pelo cpf?
            {
                var result = listaAlunos.RemoveAll(x => x.Nome == nome && x.Sobrenome == sobrenome);

                if (result == 0) //se for 0 ele nao removeu nada da lista
                    return BadRequest(Message.Failure);
                else
                    return Ok("Removeu!");
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }

        [HttpPut]
        [Route("UpdateAluno")]
        public ActionResult UpdateAluno(string cpfAluno, string novoAluno)
        {
            var result = new Result<List<Aluno>>();
            try
            {
                
                result.Data = listaAlunos.Where(x => x.CPF == cpfAluno).ToList();
                var newAluno = result.Data.Select(s =>
                {
                    s.CPF = novoAluno; 
                    return s;

                }).ToList();
                //listaAlunos.Add((Aluno) newAluno[0]);
               // listaAlunos.Add(result.Data[0]);
                
                return Ok("Trocou!");//trocou sem eu ter adicionado na lista!!!get-put
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
                return BadRequest(result);
            }

        }

    }
}

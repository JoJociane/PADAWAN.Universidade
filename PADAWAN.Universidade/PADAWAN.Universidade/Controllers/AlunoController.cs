using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PADAWAN.Universidade.Context;
using PADAWAN.Universidade.Util;
using PADAWAN.Universidade.Util.Models;

namespace PADAWAN.Universidade.Controllers
{
    [ApiController]
    [Route("CadastroAluno")]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        [Route("GetAluno")]
        public ActionResult GetAluno()
        {
            var aluno = new Aluno()//inserir para verificar, vou popular minha tabela no sql
            {
                Nome = "Joaozinho",
                Sobrenome = "da Silva",
                DataNascimento = new DateTime(1997, 12, 24),
                CPF = "796.655.920-33",
                IdCurso=2
            };

            return Ok(aluno);
        }

        [HttpPost]
        [Route("PostAluno")]//ok, mas ver questao da FK
        public ActionResult PostAluno(Aluno aluno)
        {
            var t = new Tools<Aluno>();
            if (t.Adiciona(aluno))
            {
                return Ok("Adicionou!");
            }
            else
            {
                return BadRequest("Este aluno já existe!");
            }
        }

        [HttpGet]
        [Route("BuscaAluno")]//ok
        public ActionResult BuscaAluno(string nome)
        {
            try
            {
                var t = new Tools<Aluno>();
                var encontrou = t.FindAluno(nome, out bool temaluno);
                if (!temaluno) { return BadRequest("Aluno não encontrado/cadastrado!"); }
                else
                {
                    return Ok(encontrou);
                }
            }
            catch (Exception ex)
            {
                return NotFound(Message.Failure + "----" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAluno")]//ok
        public ActionResult DeleteAluno(string nome, string sobrenome)
        {
            try
            {
                var t = new Tools<Aluno>();
                var removeu = t.DeleteAluno(nome,sobrenome);

                if (!removeu)//false
                {
                    return BadRequest("Houve algum erro! O Aluno nao foi encontrado/removido!");
                }
                else
                {
                    return Ok("Aluno Removido com Sucesso!");
                }

            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }

        [HttpPut]
        [Route("UpdateAluno")]//ok
        public ActionResult UpdateAluno(int IDaluno, string novoAluno)
        {
            try
            {
                var t = new Tools<Aluno>();
                var atualizou = t.UpdateAluno(IDaluno, novoAluno);

                if (!atualizou)//false
                {
                    return BadRequest("Houve algum erro! O Aluno nao foi encontrado/atualizado!");
                }
                else
                {
                    return Ok("Aluno Atualizado com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(Message.Failure);
            }

        }

    }
}

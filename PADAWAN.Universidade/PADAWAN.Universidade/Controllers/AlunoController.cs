using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PADAWAN.Universidade.Context;
using PADAWAN.Universidade.Util;
using PADAWAN.Universidade.Util.Models;
using PADAWAN.Universidade.Util.ErrosMensagem;
using PADAWAN.Universidade.Util.Validacoes;
using PADAWAN.Universidade.Context.Operacoes;


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
                CursoId=2
            };

            return Ok(aluno);
        }

        [HttpPost]
        [Route("PostAluno")]
        public ActionResult PostAluno(Aluno aluno)
        {
            //verifica se a data, cpf estao no formato correto
            //poderia verificar se o curso id curso esta ativo ou nao
            var t = new Tools<Aluno>();

            var dat = ValidaAluno.ValidaData(aluno.DataNascimento);
            var cpfcor = ValidaAluno.ValidaCpf(aluno.CPF);
            var name = ValidaAluno.ValidaNome(aluno.Nome);
            var verfCurso = t.VerificaCurso(aluno.CursoId);

            if (aluno.Sobrenome == "" ) { return BadRequest("Por favor informe um Nome e Sobrenome."); } //??
            if (!cpfcor) return BadRequest("Erro ao cadastrar CPF! por favor verifique formato.");
            if (!dat) return BadRequest("Erro ao cadastrar! Não possui idade mínima, ou digitou data incorreta.");
            if (!name) return BadRequest("Erro ao cadastrar Nome! Deve conter apenas letras!");
            if(!verfCurso) return BadRequest("Erro ao incluir Curso, este deve estar Inativo ou Inexistente.");

            try
            {
               
                if (t.Adiciona(aluno))
                {
                    return Ok("Adicionou!");
                }
                else
                {
                    return BadRequest("Este aluno já existe!");
                }
            }
            catch (Exception ex)
            {
                return NotFound(Message.Failure + "----" + ex.Message);
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

        [HttpGet]
        [Route("BuscaListaAluno")]//ok
        public ActionResult BuscaListaAluno()
        {
            try
            {
                var t = new Tools<Aluno>();
                var listaAlunos = t.AllAlunos();

                return Ok(listaAlunos);
                
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

                if(nome == null || sobrenome == null) { return BadRequest("Por favor informe um Nome e Sobrenome."); }
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
                if (IDaluno == null || novoAluno == null) { return BadRequest("Por favor informe um ID e o nome que deseja atualizar."); }
                
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
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }

        }

    }
}

using Microsoft.AspNetCore.Mvc;
using PADAWAN.Universidade.Context;
using PADAWAN.Universidade.Util;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PADAWAN.Universidade.API.Controllers
{
    [ApiController]
    [Route("CadastroNotas")]
    public class NotasController : ControllerBase
    {
        [HttpGet]//exemplo
        [Route("GetNota")]
        public ActionResult GetNota()
        {
            var nota = new Notas()
            {
                IdAluno=1,
                IdMateria=2,
                ValorNota=80
            };
          
            return Ok(nota); 
        }

        [HttpPost] //ok
        [Route("PostNota")]
        public ActionResult PostNota(Notas nota)
        {
            var t = new Tools<Notas>();
            if (t.Adiciona(nota))
            {
                return Ok("Adicionou!");
            }
            else
            {
                return BadRequest("Houve algum erro em adicionar a nota. ");
            }
        }

        [HttpGet]// +-
        [Route("BuscaNotaAluno")]
        public ActionResult Busca(int IdAluno)
        {
            var t = new Tools<Notas>();
            var encontrou = t.FindNota(IdAluno, out bool tem_nota);
            if (!tem_nota) { return BadRequest($"Notas não encontradas/cadastradas para o aluno."); }
            else
            {
                return Ok(encontrou);
            }

        }


        [HttpDelete]
        [Route("DeleteNota")]//ok
        public ActionResult DeleteNota(int IdAluno,int IdMateria)
        {
            try
            {
                var t = new Tools<Notas>();
                var removeu = t.DeleteNotas(IdAluno, IdMateria);

                if (!removeu)//false
                {
                    return BadRequest($"Notas não encontradas/cadastradas para o aluno.");
                }
                else
                {
                    return Ok("Nota Removida com Sucesso!");
                }
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }


        [HttpPut]
        [Route("UpdateNota")]//ok
        public ActionResult UpdateNota(int IdAluno, int IdMateria, double valor)
        {
            try
            {
                var t = new Tools<Curso>();
                var atualizou = t.UpdateNota(IdAluno, IdMateria, valor);

                if (!atualizou)//false
                {
                    return BadRequest("Houve algum erro ao atualizar a nota! Aluno ou Materia não encontrado!");
                }
                else
                {
                    return Ok("Nota Atualizada com Sucesso!");
                }
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }
    }
}

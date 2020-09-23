using Microsoft.AspNetCore.Mvc;
using PADAWAN.Universidade.Context;
using PADAWAN.Universidade.Util;
using PADAWAN.Universidade.Util.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PADAWAN.Universidade.Util.ErrosMensagem;
using PADAWAN.Universidade.Util.Validacoes;
using PADAWAN.Universidade.Context.Operacoes;

namespace PADAWAN.Universidade.API.Controllers
{
    public class MateriaCursoController : ControllerBase
    {

        [HttpGet]//exemplo
        [Route("GetMateriaCurso")]
        public ActionResult GetMateriaCurso()
        {
            var curso = new MateriaCurso()
            {
                IdMateria = 2,
                IdCurso = 2
            };
            return Ok(curso);
        }

        [HttpPost] //ok
        [Route("PostMateriaCurso")]
        public ActionResult PostMateriaCurso(int IdMateria, int IdCurso)
        { 
            var t = new Tools<MateriaCurso>();
            if (t.Adiciona(IdMateria, IdCurso))
            {
                return Ok("Adicionou!");
            }
            else
            {
                return BadRequest("Relação já existe!");
            }
        }

        [HttpGet]//ok
        [Route("BuscarMateria")]
        public ActionResult BuscarMateria(int Idmateria)
        {
            var t = new Tools<MateriaCurso>();
            var encontrou = t.FindMateria(Idmateria, out bool achou);
            if (!achou) { return BadRequest($"Materia não encontrada/cadastrada com algum curso.");}
            else
            {   //mostrar nome?
                return Ok(encontrou);
            }

        }

        [HttpDelete]
        [Route("DeleteMateriaCurso")]
        public ActionResult DeleteMC(int IdMateria, int IdCurso)
        {
            try
            {
                var t = new Tools<MateriaCurso>();
                var removeu = t.DeleteMC(IdMateria,IdCurso);

                if (!removeu)//false
                {
                    return BadRequest("Houve algum erro! A relação nao foi encontrado/removido!");
                }
                else
                {
                    return Ok("Relação Removida com Sucesso!");
                }
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }

    }
}

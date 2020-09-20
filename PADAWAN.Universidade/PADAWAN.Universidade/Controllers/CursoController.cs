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
    [Route("CadastroCurso")]
    public class CursoController : ControllerBase
    {
        [HttpGet]//exemplo
        [Route("GetCuso")]
        public ActionResult GetCurso()
        {
            var curso = new Curso()
            {
                Nome = "Ingles",
                SituacaoCurso = "Ativo"
            };
            // curso.Materias.Add(new Materia() { }); 
            return Ok(curso); //retorno o objeto para inserir no swagger
        }


        [HttpPost] //ok
        [Route("PostCurso")]
        public ActionResult PostCurso(Curso curso)//objeto vem do front
        {
            var t = new Tools<Curso>();
            if (t.Adiciona(curso))
            {
                return Ok("Adicionou!");
            }
            else
            {
                return BadRequest("Curso já existe!");
            }
        }


        [HttpGet]//ok
        [Route("BuscaCurso")]
        public ActionResult Busca(string curso)
        {
            var t = new Tools<Curso>();
            var encontrou = t.FindCurso(curso, out bool temcurso);
            if (!temcurso) { return BadRequest("Curso não encontrado/cadastrado!"); }
            else
            {
                return Ok(encontrou);
            }

        }

        [HttpDelete]
        [Route("DeleteCurso")]
        public ActionResult DeleteCurso(string curso)
        {
            try
            {
                var t = new Tools<Curso>();
                var removeu = t.DeleteCurso(curso);

                if (!removeu)//false
                {
                    return BadRequest("Houve algum erro! O Curso nao foi encontrado/removido!");
                }
                else
                {
                    return Ok("Curso Removido com Sucesso!");
                }
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }

        
        [HttpPut]
        [Route("UpdateCurso")]
        public ActionResult UpdateCurso(int IDcurso, string novocurso)
        {
            try
            {
                var t = new Tools<Curso>();
                var atualizou= t.UpdateCurso(IDcurso,novocurso);

                if (!atualizou)//false
                {
                    return BadRequest("Houve algum erro! O Curso nao foi encontrado/atualizado!");
                }
                else
                {
                    return Ok("Curso Atualizado com Sucesso!");
                }
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }

        }
    }
}

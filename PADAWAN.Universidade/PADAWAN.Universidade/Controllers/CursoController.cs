using Microsoft.AspNetCore.Mvc;
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
    public class CursoController: ControllerBase
    {
        public static List<Curso> listaCurso = new List<Curso>();

        [HttpGet]
        [Route("GetCuso")]
        public ActionResult GetCurso()
        {
            var curso = new Curso()
            {
                Nome = "Ingles",
                SituacaoCurso ="Ativo"
            };

           // curso.Materias.Add(new Materia() { }); 

            return Ok(curso);
        }

        [HttpPost]
        [Route("PostCurso")]
        public ActionResult PostCurso(Curso curso)//vem do front
        {
           if(new Curso().Adiciona(curso))
            {
                return Ok();
            }
            else
            {
                return BadRequest(Message.Failure);
            }


        }


        [HttpGet]
        [Route("BuscaCurso")]
        public ActionResult BuscaCurso(string curso)//ok
        {
            new Curso().BuscaCurso(curso);
        }

        [HttpDelete]
        [Route("DeleteCurso")]
        public ActionResult DeleteCurso(string curso)
        {
            try
            {
                var result = listaCurso.RemoveAll(x => x.Nome == curso);

                if (result == 0)
                    return BadRequest(Message.Failure);
                else
                    return Ok("Curso Removido com Sucesso!");
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }


        [HttpPut]
        [Route("UpdateCurso")]
        public ActionResult UpdateCurso(string curso, string novocurso)
        {
            var result = new Result<List<Curso>>();
            try
            {

                result.Data = listaCurso.Where(x => x.Nome == curso).ToList();


                var newMateria = result.Data.Select(s =>
                {
                    s.Nome = novocurso;
                    return s;

                }).ToList();
                return Ok("Curso Atualizado com Sucesso!");
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

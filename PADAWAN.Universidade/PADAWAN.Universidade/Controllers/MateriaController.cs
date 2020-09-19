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
    [Route("CadastroMateria")]
    public class MateriaController : ControllerBase
    {
        public static List<Materia> listaMateria = new List<Materia>(); 

        [HttpGet]
        [Route("GetMateria")]
        public ActionResult GetMateria()
        {
            var materia = new Materia()
            {
                Descricao = "Matematica",
                DataCadastro = new DateTime(1997, 12, 24),
                SituacaoMateria = "Ativa",
                
            };

            return Ok(materia);
        }

        [HttpPost]
        [Route("PostMateria")]
        public ActionResult PostMateria(Materia materia)//ok
        {
            listaMateria.Add(materia);
            return Ok();
        }

        [HttpGet]
        [Route("BuscaMateria")]
        public ActionResult BuscaMateria(string materia)//ok
        {
            try
            {
                var result = listaMateria.Where(x => x.Descricao.Contains(materia)).ToList();
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
        [Route("DeleteMateria")]
        public ActionResult DeleteMateria(string materia)
        {
            try
            {
                var result = listaMateria.RemoveAll(x => x.Descricao == materia);

                if (result == 0) 
                    return BadRequest(Message.Failure);
                else
                    return Ok("Materia Removida com Sucesso!");
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }

        [HttpPut]
        [Route("UpdateMateria")]
        public ActionResult UpdateMateria(string materia, string novamateria)
        {
            var result = new Result<List<Materia>>();
            try
            {

                result.Data = listaMateria.Where(x => x.Descricao == materia).ToList();


                var newMateria = result.Data.Select(s =>
                {
                    s.Descricao = novamateria ;
                    return s;

                }).ToList();
                return Ok("Materia Atualizada com Sucesso!");
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

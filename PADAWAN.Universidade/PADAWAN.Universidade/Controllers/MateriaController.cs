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
    [Route("CadastroMateria")]
    public class MateriaController : ControllerBase
    {
        public static List<Materia> listaMateria = new List<Materia>(); 

        [HttpGet]//exemplo
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
        [Route("PostMateria")]//ok
        public ActionResult PostMateria(Materia materia)
        {
            var t = new Tools<Materia>();
            if (t.Adiciona(materia))
            {
                return Ok("Adicionou!");
            }
            else
            {
                return BadRequest("Materia já existe!");
            }
        }

        [HttpGet]
        [Route("BuscaMateria")]//ok
        public ActionResult BuscaMateria(string materia)
        {
            try
            {
                var t = new Tools<Materia>();
                var encontrou = t.FindMateria(materia, out bool tem_mat);
                if (!tem_mat) { return BadRequest("Materia não encontrada/cadastrada!"); }
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
        [Route("DeleteMateria")]//ok
        public ActionResult DeleteMateria(string materia)
        {
            try
            {
                var t = new Tools<Materia>();
                var removeu = t.DeleteMateria(materia);

                if (!removeu)//false
                {
                    return BadRequest("Houve algum erro! A Materia nao foi encontrada/removida!");
                }
                else
                {
                    return Ok("Materia Removida com Sucesso!");
                }
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }

        [HttpPut]
        [Route("UpdateMateria")]//ok
        public ActionResult UpdateMateria(int IDmateria, string novamateria)
        {
            try
            {
                var t = new Tools<Curso>();
                var atualizou = t.UpdateMateria(IDmateria, novamateria);

                if (!atualizou)//false
                {
                    return BadRequest("Houve algum erro! A Materia nao foi encontrada/atualizada!");
                }
                else
                {
                    return Ok("Materia Atualizada com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(Message.Failure);
            }

        }


    }
}

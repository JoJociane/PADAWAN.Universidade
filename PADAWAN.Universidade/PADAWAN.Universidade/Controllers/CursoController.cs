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
        [Route("GetCurso")]
        public ActionResult GetCurso()
        {
            var curso = new Curso()
            {
                Nome = "Ingles",
                SituacaoCurso = "Ativo",
            };
            return Ok(curso);
        }


        [HttpPost] //ok
        [Route("PostCurso")]
        public ActionResult PostCurso(Curso curso)
        {
            try
            {
                var name = Aluno.ValidaNome(curso.Nome);
                if (!name) return BadRequest("Erro ao cadastrar Nome! Deve conter apenas letras!");
                
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
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }
        }


        [HttpGet]//ok
        [Route("BuscaCurso")]
        public ActionResult Busca(string curso)
        {
            try
            {
                var t = new Tools<Curso>();
                var encontrou = t.FindCurso(curso, out bool temcurso);
                if (!temcurso) { return BadRequest("Curso não encontrado/cadastrado!"); }
                else
                {
                    return Ok(encontrou);
                }
            }
            catch (Exception)
            {
                return BadRequest(Message.Failure);
            }

        }

        [HttpGet]
        [Route("BuscaListaCursos")]//ok
        public ActionResult BuscaListaCursos()
        {
            try
            {
                var t = new Tools<Curso>();
                var listaCursos = t.AllCursos();

                return Ok(listaCursos);

            }
            catch (Exception ex)
            {
                return NotFound(Message.Failure + "----" + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCurso")]//ok
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
        [Route("UpdateCurso")]//ok
        public ActionResult UpdateCurso(int IDcurso, string novocurso, string status)
        {
            try
            {
                if (IDcurso == null || novocurso == null) { return BadRequest("Por favor informe um ID e o nome que deseja atualizar."); }
                
                var t = new Tools<Curso>();
                
                var atualizou= t.UpdateCurso(IDcurso,novocurso,status);

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

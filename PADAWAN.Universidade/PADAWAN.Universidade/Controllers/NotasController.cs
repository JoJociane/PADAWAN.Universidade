using Microsoft.AspNetCore.Mvc;
using PADAWAN.Universidade.Context;
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
       /*
        
        [HttpPost]
        [Route("PostNotas")]
        public ActionResult PostNotas(NotasController notas)//vem do front
        {
            var t = new Tools<Notas>();


            if (t.Adiciona(notas))
            {
                return Ok("Adicionou!");
            }
            else
            {
                return BadRequest("Curso já existe!");
            }


        }

        */

    }
}

using Microsoft.AspNetCore.Mvc;
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
                Descricao= "Matematica",
                DataCadastro = new DateTime(1997, 12, 24),
            };

            return Ok();
        }

        [HttpPost]
        [Route("PostMateria")]
        public ActionResult PostMateria(Materia materia)//ok
        {
            listaMateria.Add(materia);
            return Ok();
        }

       




    }
}

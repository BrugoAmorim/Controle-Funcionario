using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargosController : ControllerBase
    {
        Utils.CargosUtils conversor = new Utils.CargosUtils();


        // faz uma consulta no banco e retorna uma lista com todos os cargos da empresa
        [HttpGet("buscar-cg")]
        public List<Models.Response.DescCargoResponse> lstcargos(){

            Database.CargoDatabase tbcargos = new Database.CargoDatabase();

            List<Models.TbCargo> cgs = tbcargos.lista();
            List<Models.Response.DescCargoResponse> caixote = conversor.convTBlista(cgs);
            return caixote;
        }
    }
}
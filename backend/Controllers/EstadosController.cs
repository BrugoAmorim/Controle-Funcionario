using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadosController : ControllerBase
    {
        [HttpGet("buscar-est")]
        public List<Models.Response.EstadosResponse> buscarestados(){

            Database.EstadosDatabase bd = new Database.EstadosDatabase();
            List<Models.Response.EstadosResponse> res = new List<Models.Response.EstadosResponse>();

            // busca todos os estados e retorna em um modelo tb
            List<Models.TbEstado> lst = bd.listarEstados();

            foreach(Models.TbEstado item in lst){

                Models.Response.EstadosResponse i = new Models.Response.EstadosResponse();
                i.idestado = item.IdEstado;
                i.estado = item.NmEstado;

                res.Add(i);
            }

            return res;
        }
    }
}
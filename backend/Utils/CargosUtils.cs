using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Utils
{
    public class CargosUtils
    {
        public Models.Response.DescCargoResponse convTB(Models.TbCargo req){

            Models.Response.DescCargoResponse desc = new Models.Response.DescCargoResponse();

            desc.cargo = req.DsCargo;
            desc.idcargo = req.IdCargo;
            desc.salario = req.VlSalario;
            desc.horarioentrada = req.HrEntrada;
            desc.horariosaida = req.HrSaida;

            return desc;
        }

        public List<Models.Response.DescCargoResponse> convTBlista(List<Models.TbCargo> req){

            List<Models.Response.DescCargoResponse> cargos = new List<Models.Response.DescCargoResponse>();

            foreach(Models.TbCargo item in req){

                cargos.Add(convTB(item));
            }

            return cargos;
        }
    }
}
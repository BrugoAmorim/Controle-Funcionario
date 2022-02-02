using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class CargoDatabase
    {
        Models.bdfuncionarioContext ctx = new Models.bdfuncionarioContext();
        public bool validarcargo(string departamento){

            List<Models.TbCargo> cargos = ctx.TbCargos.ToList();

            bool vazio = cargos.Any(x => x.DsCargo == departamento);
            return vazio;
        }

        public Models.TbCargo buscarCargo(string cargo){

            Models.TbCargo info = ctx.TbCargos.First(x => x.DsCargo == cargo);
            return info;
        }
    }
}
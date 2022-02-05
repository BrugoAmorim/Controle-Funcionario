using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class CargoDatabase
    {
        Models.bdfuncionarioContext ctx = new Models.bdfuncionarioContext();

        // busca um cargo atraves do nome e valida se ele existe ou nao
        public bool validarcargo(string departamento){

            List<Models.TbCargo> cargos = ctx.TbCargos.ToList();

            bool vazio = cargos.Any(x => x.DsCargo == departamento);
            return vazio;
        }

        // busca as informacoes de um cargo atraves do nome
        public Models.TbCargo buscarCargo(string cargo){

            Models.TbCargo info = ctx.TbCargos.First(x => x.DsCargo == cargo);
            return info;
        }
    
        // retorna uma lista com os cargos da empresa
        public List<Models.TbCargo> lista(){

            List<Models.TbCargo> departamentos = ctx.TbCargos.ToList();
            return departamentos;
        }
    }
}
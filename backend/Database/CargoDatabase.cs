using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class CargoDatabase
    {
        Models.bdfuncionarioContext ctx = new Models.bdfuncionarioContext();

        // busca um cargo atraves do id e valida se ele existe ou nao
        public bool validarcargo(int idcargo){

            List<Models.TbCargo> cargos = ctx.TbCargos.ToList();

            bool vazio = cargos.Any(x => x.IdCargo == idcargo);
            return vazio;
        }

        // busca as informacoes de um cargo atraves do id
        public Models.TbCargo buscarCargo(int cargo){

            Models.TbCargo info = ctx.TbCargos.First(x => x.IdCargo == cargo);
            return info;
        }
    
        // retorna uma lista com os cargos da empresa
        public List<Models.TbCargo> lista(){

            List<Models.TbCargo> departamentos = ctx.TbCargos.ToList();
            return departamentos;
        }

        // procura as informacoes do cargo pelo nome
        public Models.TbCargo buscarpornome(string cargo){
            
            List<Models.TbCargo> cargos = ctx.TbCargos.ToList();

            Models.TbCargo cg = cargos.FirstOrDefault(x => x.DsCargo == cargo);
            return cg;
        }
    }
}
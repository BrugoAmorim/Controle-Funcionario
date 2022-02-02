using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class FuncionarioDatabase
    {
        Models.bdfuncionarioContext ctx = new Models.bdfuncionarioContext();
        Utils.FuncsUtils converter = new Utils.FuncsUtils();

        // procura os registros dos funcionarios
        public List<Models.TbFuncionario> procuraReg(){

            List<Models.TbFuncionario> caixote = ctx.TbFuncionarios.Include(x => x.IdEstadoNavigation).Include(x => x.IdCargoNavigation).ToList();

            return caixote;
        }

        // inseri um funcionario por vez no banco
        public Models.Response.FuncionarioResponse inserirfunc(Models.Request.FuncionarioRequest req){

            Database.CargoDatabase buscarcargo = new Database.CargoDatabase();
            Database.EstadosDatabase buscarestado = new Database.EstadosDatabase();

            Models.TbCargo cg = buscarcargo.buscarCargo(req.cargo);
            Models.TbEstado est = buscarestado.buscarestado(req.estadonasc);

            Models.TbFuncionario func = converter.reqFuncparaTb(req);
            func.IdCargo = cg.IdCargo;
            func.IdEstado = est.IdEstado;

            ctx.TbFuncionarios.Add(func);
            ctx.SaveChanges();

            Models.Response.FuncionarioResponse res = converter.modelRes(func, est.NmEstado, cg.DsCargo);
            return res;
        }
    }
}
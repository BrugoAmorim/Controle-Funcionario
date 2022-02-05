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

        //verificar se este funcionario esta no sistema
        public Models.TbFuncionario buscainfo(int id){

            Models.TbFuncionario registro = ctx.TbFuncionarios.FirstOrDefault(x => x.IdFuncionario == id);

            return registro;
        }

        // altera os registros de um funcionario, informando o seu id
        public Models.Response.FuncionarioResponse atualizar(int id, Models.Request.FuncionarioRequest req){

            Database.CargoDatabase buscarcargo = new Database.CargoDatabase();
            Database.EstadosDatabase buscarestado = new Database.EstadosDatabase();

            // ele vai buscar registros referentes ao nomes dados no buscarcargo e buscarestado
            Models.TbCargo cg = buscarcargo.buscarCargo(req.cargo);
            Models.TbEstado est = buscarestado.buscarestado(req.estadonasc);

            // ele pega o registro do funcionario atraves do id e copia as informacoes do req
            Models.TbFuncionario registro = ctx.TbFuncionarios.First(x => x.IdFuncionario == id);
            registro.NmFuncionario = req.nome;
            registro.DsCpf = req.cpf;
            registro.DsRg = req.rg;
            registro.DsTelefone = req.telefone;
            registro.DsCelular = req.celular;
            registro.IdCargo = cg.IdCargo;
            registro.IdEstado = est.IdEstado;
            ctx.SaveChanges();

            Models.Response.FuncionarioResponse res = converter.modelRes(registro, est.NmEstado, cg.DsCargo);

            return res;
        }

        // deleta os registros de um funcionario atraves do id
        public void confirmardelete(int idfuncionario){

            Models.TbFuncionario infofunc = ctx.TbFuncionarios.First(x => x.IdFuncionario == idfuncionario);

            ctx.TbFuncionarios.Remove(infofunc);
            ctx.SaveChanges();
        }
    }
}
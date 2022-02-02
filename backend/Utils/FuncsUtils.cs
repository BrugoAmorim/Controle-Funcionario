using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Utils
{
    public class FuncsUtils
    {
        // converte um modelo tb funcionario para modelo response com idnavigation
        public Models.Response.FuncionarioResponse funcres(Models.TbFuncionario req){

            Models.Response.FuncionarioResponse ctx = new Models.Response.FuncionarioResponse();

            ctx.nome = req.NmFuncionario;
            ctx.idfunc = req.IdFuncionario;
            ctx.rg = req.DsRg;
            ctx.cpf = req.DsCpf;
            ctx.estadonasc = req.IdEstadoNavigation.NmEstado;
            ctx.cargo = req.IdCargoNavigation.DsCargo;
            ctx.datacontratado = req.DtContratado;

            if(req.DsCelular == "" || req.DsCelular == null)
                ctx.celular = "não informado";
            else
                ctx.celular = req.DsCelular;

            if(req.DsTelefone == ""|| req.DsTelefone == null)
                ctx.telefone = "não informado";
            else
                ctx.telefone = req.DsTelefone;

            return ctx; 
        }

        // converte uma lista tb funcionario para uma lista response
        public List<Models.Response.FuncionarioResponse> lstfunc(List<Models.TbFuncionario> req){

            List<Models.Response.FuncionarioResponse> lst = new List<Models.Response.FuncionarioResponse>();

            foreach(Models.TbFuncionario item in req){

                lst.Add(funcres(item));
            }

            return lst;
        }

        // converte um modelo request funcionario para um modelo de tabela
        public Models.TbFuncionario reqFuncparaTb(Models.Request.FuncionarioRequest req){

            Models.TbFuncionario model = new Models.TbFuncionario();
            DateTime hj = DateTime.Now;

            model.NmFuncionario = req.nome;
            model.DsCpf = req.cpf;
            model.DsRg = req.rg;
            model.DsTelefone = req.telefone;
            model.DsCelular = req.celular;
            model.DtContratado = new DateTime(hj.Year, hj.Month, hj.Day);

            return model;
        }

        // converte um modelo de tabela para response sem o idnavigation
        public Models.Response.FuncionarioResponse modelRes(Models.TbFuncionario req, string estnasc, string departamento){

            Models.Response.FuncionarioResponse ctx = new Models.Response.FuncionarioResponse();

            ctx.nome = req.NmFuncionario;
            ctx.idfunc = req.IdFuncionario;
            ctx.rg = req.DsRg;
            ctx.cpf = req.DsCpf;
            ctx.estadonasc = estnasc;
            ctx.cargo = departamento;
            ctx.datacontratado = req.DtContratado;

            if(req.DsCelular == "")
                ctx.celular = "não informado";
            else
                ctx.celular = req.DsCelular;

            if(req.DsTelefone == "")
                ctx.telefone = "não informado";
            else
                ctx.telefone = req.DsTelefone;

            return ctx; 
        }

    }
}
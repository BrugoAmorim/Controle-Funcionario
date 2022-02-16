using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class AtualizarFuncionario
    {
        Database.CargoDatabase bdcargo = new Database.CargoDatabase();
        Database.EstadosDatabase bdestado = new Database.EstadosDatabase();
        Database.FuncionarioDatabase salvar = new Database.FuncionarioDatabase();

        public Models.Response.AtualizarFuncionarioResponse validarupdate(Models.Request.AtualizarFuncionarioResquest rq,int idfunc){

            bool reg1 = bdestado.validarestado(rq.idest);
            bool reg2 =  bdcargo.validarcargo(rq.idcg);

            if(salvar.buscainfo(idfunc) == null)
                throw new ArgumentException("Este Funcionário não foi encontrado no sistema");

            if(string.IsNullOrEmpty(rq.nome))
                throw new ArgumentException("É necessário informar o nome do funcionário");

            if(string.IsNullOrEmpty(rq.rg))
                throw new ArgumentException("Campo do Rg vazio");
            
            if(string.IsNullOrEmpty(rq.cpf))
                throw new ArgumentException("Campo do Cpf vazio");

            if(rq.cpf.Length < 11 || rq.cpf.Length > 12)
                throw new ArgumentException("insira um Cpf válido");
                
            if(rq.rg.Length < 9 || rq.rg.Length > 12)
                throw new ArgumentException("insira um Rg válido");

            if(rq.telefone.Length != 8 && rq.telefone != "")
                throw new ArgumentException("Número de telefone inválido");

            if(rq.celular.Length != 12 && rq.celular != "")
                throw new ArgumentException("Número do celular inválido");

            if(reg1 == false)
                throw new ArgumentException("Este estado não existe");
            
            if(reg2 == false)
                throw new ArgumentException("Este cargo não existe");
            
            Models.Response.AtualizarFuncionarioResponse res = salvar.atualizar(rq.idcg, rq.idest, idfunc,rq);
            return res;
        }
    }
}
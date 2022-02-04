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

        public Models.Response.FuncionarioResponse validarupdate(Models.Request.FuncionarioRequest rq, int id){

            if(salvar.buscainfo(id) == null)
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

            if(bdestado.validarestado(rq.estadonasc) != true || string.IsNullOrEmpty(rq.estadonasc))
                throw new ArgumentException("Este estado não existe");
            
            if(bdcargo.validarcargo(rq.cargo) != true || string.IsNullOrEmpty(rq.cargo))
                throw new ArgumentException("Este cargo não foi encontrado");

            Models.Response.FuncionarioResponse res = salvar.atualizar(id, rq);
            return res;
        }   
    }
}
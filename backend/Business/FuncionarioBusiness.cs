using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class FuncionarioBusiness
    {
        Database.FuncionarioDatabase banco = new Database.FuncionarioDatabase();
        public List<Models.TbFuncionario> verificarlst(){

            List<Models.TbFuncionario> lst = banco.procuraReg();

            if(lst.Count == 0)
                throw new ArgumentException("Não encontramos nenhum registro");

            return lst;
        }
    
        public List<Models.TbFuncionario> verificaparam(string ct){

            List<Models.TbFuncionario> funcs = banco.procuraReg();

            if(ct == "Mais_Novos")
                funcs = funcs.OrderByDescending(x => x.DtContratado).ToList();

            else if(ct == "Mais_Antigos")
                funcs = funcs.OrderBy(x => x.DtContratado).ToList();

            else if(funcs.Count == 0)
                throw new ArgumentException("Não há registros de funcionários");

            else
                return funcs;

            return funcs;
        }
    }
}
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
    }
}
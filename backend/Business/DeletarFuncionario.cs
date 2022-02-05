using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Business
{
    public class DeletarFuncionario
    {
        Database.FuncionarioDatabase banco = new Database.FuncionarioDatabase();

        public void validardelete(int id){

            Models.TbFuncionario info = banco.buscainfo(id);

            if(info == null)
                throw new ArgumentException("Este funcionário não existe");

            banco.confirmardelete(id);
        }
    }
}
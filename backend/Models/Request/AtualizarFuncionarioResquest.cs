using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Request
{
    public class AtualizarFuncionarioResquest
    {
        public int idest {get; set;}
        public int idcg {get;set;}
        public string nome {get; set;}
        public string rg {get;set;}
        public string cpf {get;set;}
        public string telefone {get;set;}
        public string celular {get;set;}
    }
}
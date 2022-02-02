using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class FuncionarioResponse
    {
        public int idfunc {get;set;}
        public string nome {get; set;}
        public string rg {get;set;}
        public string cpf {get;set;}
        public string cargo {get;set;}
        public string estadonasc {get;set;}
        public DateTime datacontratado {get;set;}
        public string telefone {get;set;}
        public string celular {get;set;}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Response
{
    public class DescCargoResponse
    {

        public int idcargo {get;set;}
        public string cargo {get;set;}
        public decimal salario {get;set;}
        public TimeSpan horarioentrada {get;set;}
        public TimeSpan horariosaida {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class EstadosDatabase
    {
        Models.bdfuncionarioContext ctx = new Models.bdfuncionarioContext();
        public bool validarestado(string estad){

            List<Models.TbEstado> estados = ctx.TbEstados.ToList();

            bool existente = estados.Any(x => x.NmEstado == estad);
            return existente;
        }   

        public Models.TbEstado buscarestado(string estado){

            Models.TbEstado est = ctx.TbEstados.First(x => x.NmEstado == estado);
            return est;
        }
    }
}
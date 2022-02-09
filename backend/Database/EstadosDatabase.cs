using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class EstadosDatabase
    {

        Models.bdfuncionarioContext ctx = new Models.bdfuncionarioContext();
        
        // procura por pelo menos um estado que exista no banco atraves do nome
        public bool validarestado(string estad){

            List<Models.TbEstado> estados = ctx.TbEstados.ToList();

            bool existente = estados.Any(x => x.NmEstado == estad);
            return existente;
        }   

        // procura o registro do estado atraves do nome e retorna suas informacoes
        public Models.TbEstado buscarestado(string estado){

            Models.TbEstado est = ctx.TbEstados.First(x => x.NmEstado == estado);
            return est;
        }

        // busca uma lista com todos os estados
        public List<Models.TbEstado> listarEstados(){

            List<Models.TbEstado> caixote = ctx.TbEstados.ToList();
            return caixote;
        }
    }
}
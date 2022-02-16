using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Database
{
    public class EstadosDatabase
    {

        Models.bdfuncionarioContext ctx = new Models.bdfuncionarioContext();
        
        // procura um estado atraves do id e retorna suas informacoes, caso exista
        public bool validarestado(int idestado){

            List<Models.TbEstado> estados = ctx.TbEstados.ToList();

            bool existente = estados.Any(x => x.IdEstado == idestado);
            return existente;
        }   


        // procura o registro do estado atraves do id e retorna suas informacoes
        public Models.TbEstado buscarestado(int estado){

            List<Models.TbEstado> estados = ctx.TbEstados.ToList();

            Models.TbEstado est = estados.First(x => x.IdEstado == estado);
            return est;
        }

        // busca uma lista com todos os estados
        public List<Models.TbEstado> listarEstados(){

            List<Models.TbEstado> caixote = ctx.TbEstados.ToList();
            return caixote;
        }

        // busca as informacoes pelo nome
        public Models.TbEstado buscarpornome(string est){
                        
            List<Models.TbEstado> estados = ctx.TbEstados.ToList();

            Models.TbEstado ests = estados.FirstOrDefault(x => x.NmEstado == est);
            return ests;
        }
    }
}
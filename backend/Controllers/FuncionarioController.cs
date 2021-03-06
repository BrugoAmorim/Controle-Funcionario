using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        Utils.FuncsUtils conversor = new Utils.FuncsUtils();

        /*
        [HttpGet("buscar-func")]
        public ActionResult<List<Models.Response.FuncionarioResponse>> cadastrados(){

            try{
                Business.FuncionarioBusiness validar = new Business.FuncionarioBusiness();
                
                List<Models.TbFuncionario> caixote = validar.verificarlst();

                List<Models.Response.FuncionarioResponse> res = conversor.lstfunc(caixote);
                return res;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        } */

        [HttpPost("reg-func")]
        public ActionResult<Models.Response.FuncionarioResponse> registrarfunc(Models.Request.FuncionarioRequest req){

            try{
                Business.RegistrarFuncionario salvarbanco = new Business.RegistrarFuncionario();

                Models.Response.FuncionarioResponse caixote =  salvarbanco.validaRegistro(req);
                return caixote;
            }
            catch(System.Exception ex){
                
                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPut("info-func/{idfunc}")]
        public ActionResult<Models.Response.AtualizarFuncionarioResponse> alterarinformacoes(Models.Request.AtualizarFuncionarioResquest update, int idfunc)
        {
            try{
                Business.AtualizarFuncionario validar = new Business.AtualizarFuncionario();

                Models.Response.AtualizarFuncionarioResponse res = validar.validarupdate(update, idfunc);   
                return res;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpDelete("del-func/{idfunc}")]
        public ActionResult<string> deletarRegistro(int idfunc){

            try{
                Business.DeletarFuncionario apagar = new Business.DeletarFuncionario();

                apagar.validardelete(idfunc);
                return "Deletado com Sucesso!";
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        // funcao de ordenar funcionarios, retorna os mais novos ou os funcionarios mais antigos da empresa, se nao houver filtros ele retornar?? uma lista normal
        [HttpGet("filtrar-func")]
        public ActionResult<List<Models.Response.FuncionarioResponse>> filtrofunc(string contratado){

            try{
                Business.FuncionarioBusiness validarget = new Business.FuncionarioBusiness();

                List<Models.TbFuncionario> caixote = validarget.verificaparam(contratado);
                List<Models.Response.FuncionarioResponse> res = conversor.lstfunc(caixote);

                return res;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    
    }
}
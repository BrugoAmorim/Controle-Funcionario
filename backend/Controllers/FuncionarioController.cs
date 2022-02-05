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
        }

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
        public ActionResult<Models.Response.FuncionarioResponse> alterarinformacoes(Models.Request.FuncionarioRequest update, int idfunc)
        {
            try{
                Business.AtualizarFuncionario validar = new Business.AtualizarFuncionario();

                Models.Response.FuncionarioResponse reg = validar.validarupdate(update, idfunc);
                return reg;
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
    }
}
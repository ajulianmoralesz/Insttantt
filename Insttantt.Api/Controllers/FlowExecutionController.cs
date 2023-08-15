using Insttantt.Application.Bussines.Fields.Queries;
using Insttantt.Application.Bussines.FlowExecutions.Commands.Creates;
using Insttantt.Application.Bussines.FlowExecutions.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowExecutionController : CustomBaseController
    {
        /// <summary>
        /// Obtiene una lista de todas las ejecucion de flujos disponibles
        /// </summary>
        /// <returns></returns>
        /// 

        
        [HttpGet]
        public async Task<IActionResult> ExecuteFlow()
        {
            var result = await Mediator.Send(new GetExecutionsQuery() { });
            return HandleResult(result.Result, result.ErrorProvider);
        }

        /// <summary>
        /// Inicializa un nuevo flujo o continua un flujo que ya estaba inicializado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ExecuteFlow(ExecuteFlowCommand command)
        {
            var result = await Mediator.Send(command);
            return HandleResult(result.Result, result.ErrorProvider);
        }

        /// <summary>
        /// Obtiene las variables resultado de una ejecución parcial o total de un flujo
        /// </summary>
        /// <param name="idExecution">Id de la ejecución</param>
        /// <returns></returns>
        [HttpPost("getexecutionvariables", Name = "GetFlowExecutionVariables")]
        public async Task<IActionResult> GetFlowExecutionVariables(int idExecution)
        {
            var result = await Mediator.Send(new GetExecutionVariablesQuery() { IdExecution = idExecution});
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

using Insttantt.Application.Bussines.Flows.Commands.Creates;
using Insttantt.Application.Bussines.Flows.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController : CustomBaseController
    {
        /// <summary>
        /// Obtiene una lista de todos los flujos disponibles para ejecutar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetFlows()
        {
            var result = await Mediator.Send(new GetFlowsQuery());
            return HandleResult(result.Result, result.ErrorProvider);
        }

        /// <summary>
        /// Permite crear un flujo con todas sus configuraciones
        /// </summary>
        /// <param name="flowCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateFlow(CreateFlowCommand flowCommand)
        {
            var result = await Mediator.Send(flowCommand);
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

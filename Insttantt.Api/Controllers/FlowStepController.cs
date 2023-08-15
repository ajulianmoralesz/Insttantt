using Insttantt.Application.Bussines.FlowSteps.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowStepController : CustomBaseController
    {
        /// <summary>
        /// Obtiene la lista de los pasos pendientes en una ejecucion. Si hay un Id de ejecucion retorna una lista con los pasos pendientes del flujo. Si no se envia un id de ejeución de ejecucion lista todos los pasos de un flujo
        /// </summary>
        /// <param name="idFlow">Id del flujo</param>
        /// <param name="idExecution">Id de la ejecucion</param>
        /// <returns></returns>
        [HttpGet("getpendingsteps", Name = "GetPendingSteps")]
        public async Task<IActionResult> GetPendingSteps(int idFlow, int? idExecution)
        {
            var result = await Mediator.Send(new GetPendingStepsQuery() { IdFlow = idFlow, IdExecution = idExecution});
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

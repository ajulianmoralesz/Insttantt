using Insttantt.Application.Bussines.Steps.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : CustomBaseController
    {
        /// <summary>
        /// Obtiene un lista de todos los pasos disponibles para la creación de un flujo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSteps()
        {
            var result = await Mediator.Send(new GetStepsQuery());
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

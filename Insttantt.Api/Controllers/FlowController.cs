using Insttantt.Application.Bussines.Flows.Commands.Creates;
using Insttantt.Application.Bussines.Flows.Queries;
using Insttantt.Application.Bussines.Weather.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetFlows()
        {
            var result = await Mediator.Send(new GetFlowsQuery());
            return HandleResult(result.Result, result.ErrorProvider);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlow(CreateFlowCommand flowCommand)
        {
            var result = await Mediator.Send(flowCommand);
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

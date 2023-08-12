using Insttantt.Application.Bussines.Fields.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetFields()
        {
            var result = await Mediator.Send(new GetFieldsQuery());
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

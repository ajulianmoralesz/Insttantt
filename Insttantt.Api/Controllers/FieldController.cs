using Insttantt.Application.Bussines.Fields.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : CustomBaseController
    {
        /// <summary>
        /// Obtiene una lista de todos los campos disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetFields()
        {
            var result = await Mediator.Send(new GetFieldsQuery());
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

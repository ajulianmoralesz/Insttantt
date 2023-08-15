using Insttantt.Steps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Steps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        [HttpPost("inputparameters", Name = "InputParameters")]
        public IActionResult InputParameters(OperationModel model)
        {
            return Ok(new { result = true });
        }
    }
}

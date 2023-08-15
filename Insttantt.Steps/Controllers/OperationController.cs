using Insttantt.Steps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Steps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpPost("adittion", Name = "Adittion")]
        public IActionResult Adittion(OperationModel model)
        {
            return Ok(new { result = model.X + model.Y });
        }
        [HttpPost("subtraction", Name = "Subtraction")]
        public IActionResult Subtraction(OperationModel model)
        {
            return Ok(new { result = model.X - model.Y });
        }
        [HttpPost("multiplication", Name = "Multiplication")]
        public IActionResult Multiplication(OperationModel model)
        {
            return Ok(new { result = model.X * model.Y });
        }
        [HttpPost("division", Name = "Division")]
        public IActionResult Division(OperationModel model)
        {
            return Ok(new { result = model.X / model.Y });
        }

        [HttpPost("compound", Name = "Compound")]
        public IActionResult Compound(CompaundOperationModel model)
        {
            return Ok(new { result = (model.W  * model.X) - model.Y + model.Z });
        }
    }

    
}

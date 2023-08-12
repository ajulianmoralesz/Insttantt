using Insttantt.Application.Handlers.ResponseHandlers.Wrappers;
using Insttantt.Application.ServiceErrorHandlers;
using Insttantt.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

        [ApiExplorerSettingsAttribute(IgnoreApi = true)]
        public IActionResult HandleResult([FromBody] object data, [FromQuery] ErrorServiceProvider errors)
        {
            if (errors.HasError())
            {
                return BadRequest(new
                    ApiResponse(null,
                        errors.GetWarnings(),
                        409,
                        ResponseMessageEnum.Failure,
                        errors.GetErrors()
                    ));
            }
            else
            {
                return Ok(new ApiResponse(data, errors.GetWarnings()));
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Insttantt.Application.Handlers.ResponseHandlers.Wrappers;

namespace Insttantt.Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case CustomValidationException validationEx:
                    HandleCustomValidationException(context, validationEx);
                    break;
                default:
                    HandleDefaultException(context);
                    break;
            }
            base.OnException(context);
        }

        private void HandleCustomValidationException(ExceptionContext context, CustomValidationException exception)
        {
            context.Result = new ObjectResult(new { mensaje = exception.Errors.ElementAt(0).Value.FirstOrDefault() })
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
            context.ExceptionHandled = true;
        }

        private void HandleDefaultException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new { mensaje = context.Exception.Message })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}

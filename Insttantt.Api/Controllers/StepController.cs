﻿using Insttantt.Application.Bussines.Steps.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetSteps()
        {
            var result = await Mediator.Send(new GetStepsQuery());
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}

using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.FlowExecutionFields.Commands;
using Insttantt.Application.Bussines.FlowExecutions.DTO;
using Insttantt.Application.Bussines.Models;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowExecutions.Commands.Creates
{
    internal class ExecuteStepCommand : IRequest<Response<bool>>
    {
        public int IdFlowExecution { get; set; }
        public int? IdOutputField { get; set; }
        public string Url { get; set; }
        public List<ExecutionVariablesDto> Parameters { get; set; } = new List<ExecutionVariablesDto>();
    }

    internal class ExecuteStepCommandHandler : IRequestHandler<ExecuteStepCommand, Response<bool>>
    {
        #region vars
        private readonly ISender _sender;

        #endregion

        #region ctor
        public ExecuteStepCommandHandler(ISender sender)
        {
            _sender = sender;
        }
        #endregion
        public async Task<Response<bool>> Handle(ExecuteStepCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var client = new HttpClient();

                var dict = new Dictionary<string, object>();
                request.Parameters.ForEach(x =>
                {
                    dict.Add(x.Code, x.Value);
                });
                var myContent = JsonConvert.SerializeObject(dict);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var stepReponse = client.PostAsync(request.Url, byteContent);
                var stepResult = await stepReponse.Result.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                var value = Convert.ToString(stepResult.GetValueOrDefault("result", string.Empty));

                #region Create Output Variable
                if (request.IdOutputField.HasValue && request.IdOutputField > 0)
                {
                    await _sender.Send(new CreateFlowExecutionFieldCommand() { IdFlowExecution = request.IdFlowExecution, Value = value, IdFlowStepField = request.IdOutputField.Value });
                }
                #endregion

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }
    }
}

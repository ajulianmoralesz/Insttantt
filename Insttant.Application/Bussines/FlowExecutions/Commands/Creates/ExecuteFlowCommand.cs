using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.FlowExecutionFields.Commands;
using Insttantt.Application.Bussines.FlowExecutions.Queries;
using Insttantt.Application.Bussines.Flows.Commands.Creates;
using Insttantt.Application.Bussines.FlowSteps.Queries;
using Insttantt.Application.Bussines.FlowSteps.Queries.DTO;
using Insttantt.Application.Bussines.Models;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Insttantt.Application.Bussines.FlowExecutions.Commands.Creates
{
    public class ExecuteFlowCommand : IRequest<Response<FlowExecutionResponse>>
    {
        public int IdFlow { get; set; }
        public int? IdExecution { get; set; }
        public List<FlowExecutionFieldInput> Fields { get; set; } = new List<FlowExecutionFieldInput>();
    }

    public class ExecuteFlowCommandHandler : IRequestHandler<ExecuteFlowCommand, Response<FlowExecutionResponse>>
    {
        #region vars
        private readonly IRepository<Flow> _flowRepo;
        private readonly IRepository<FlowExecution> _flowExecRepo;
        private readonly IRepository<FlowExecutionField> _flowExecFieldRepo;
        private readonly ISender _sender;
        #endregion

        #region ctor
        public ExecuteFlowCommandHandler(IRepository<Flow> flowRepo, IRepository<FlowExecution> flowExecRepo, IRepository<FlowExecutionField> flowExecFieldRepo, ISender sender)
        {
            _flowRepo = flowRepo;
            _flowExecRepo = flowExecRepo;
            _flowExecFieldRepo = flowExecFieldRepo;
            _sender = sender;
        }
        #endregion
        public async Task<Response<FlowExecutionResponse>> Handle(ExecuteFlowCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<FlowExecutionResponse>();
            try
            {
                FlowExecution executionFlow = null;
                if(request.IdExecution != null && request.IdExecution > 0)
                {
                    executionFlow = await _flowExecRepo.GetByIdAsync(request.IdExecution.Value);
                }
                else
                {
                    executionFlow = (await _sender.Send(new CreateFlowExecutionCommand() { IdFlow = request.IdFlow })).Result;
                }                
                var pendingSteps = (await _sender.Send(new GetPendingStepsQuery() { IdExecution = request.IdExecution, IdFlow = request.IdFlow })).Result;
                #region Get Saved and New Variables
                var dictInputs = (await _sender.Send(new GetExecutionVariablesQuery() { IdExecution = request.IdExecution })).Result;
                foreach (var field in request.Fields)
                {
                    var idStepField = GetFieldStepId(pendingSteps, field.Code);
                    if (idStepField.HasValue)
                    {
                        dictInputs.Add(new DTO.ExecutionVariablesDto() { Id = 0, Code = field.Code, IdFlowStepField = idStepField.Value, Value = Convert.ToString(field.Value) });

                    }
                }
                #region Create New Input Variables
                var creates = dictInputs.Where(x => x.Id == 0).Select(x => _sender.Send(new CreateFlowExecutionFieldCommand() { IdFlowExecution = executionFlow.Id, Value = x.Value, IdFlowStepField = x.IdFlowStepField })).ToList();
                await Task.WhenAll(creates);
                #endregion

                #endregion

                var taskList = new List<Task<Response<bool>>>();
                foreach (var step in pendingSteps)
                {
                    var withoutOutputs = step.Fields.Where(x => !x.IsOutput).ToList();
                    var inputParameters = withoutOutputs.Where(x => dictInputs.Count(y => y.Code == x.Code) > 0).ToList();
                    if (withoutOutputs.Count == inputParameters.Count)
                    {
                        var currentDict = dictInputs.Where(x => withoutOutputs.Count(y => y.Code == x.Code) > 0).ToList();
                        var outputId = step.Fields.FirstOrDefault(x => x.IsOutput)?.Id;
                        taskList.Add(_sender.Send(new ExecuteStepCommand() { Url = step.Url, IdFlowExecution = executionFlow.Id, Parameters = currentDict, IdOutputField = outputId }));                        
                    }
                }
                if(taskList.Count <= 0)
                {
                    response.ErrorProvider.AddWarning("400", "It is not possible to execute any step with the information provided");
                    return response;
                }
                var result = await Task.WhenAll(taskList);
                response.Result = new FlowExecutionResponse()
                {
                    FlowExecutionId = executionFlow.Id,
                    ExecutedSteps = result.Length,
                    Succes = result.Where(x=> !x.ErrorProvider.HasError()).Count(),
                    Errors = result.Where(x => x.ErrorProvider.HasError()).Count(),
                };

                result.ToList().ForEach(x => {
                    response.ErrorProvider.AddErrorList(x.ErrorProvider.GetErrors());
                });
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }

        public int? GetFieldStepId(List<PendingStepDto> pendingSteps, string Code)
        {
            return pendingSteps.FirstOrDefault(x => x.Fields.Count(y => y.Code == Code) > 0)?.Fields.FirstOrDefault(x => x.Code == Code)?.Id;
        }
         
    }
}

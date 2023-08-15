using Insttant.DataAccess.Repositories;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowExecutions.Commands.Creates
{
    internal class CreateFlowExecutionCommand : IRequest<Response<FlowExecution>>
    {
        public int IdFlow { get; set; }
    }
    internal class CreateFlowExecutionHandler : IRequestHandler<CreateFlowExecutionCommand, Response<FlowExecution>>
    {
        #region vars
        private readonly IRepository<FlowExecution> _flowExecRepo;
        #endregion

        #region ctor
        public CreateFlowExecutionHandler(IRepository<FlowExecution> flowExecRepo)
        {
            _flowExecRepo = flowExecRepo;
        }
        #endregion
        public async Task<Response<FlowExecution>> Handle(CreateFlowExecutionCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<FlowExecution>();
            try
            {
                var flowExec = NewEntity(request.IdFlow);
                _flowExecRepo.Add(flowExec);
                await _flowExecRepo.SaveAsync(cancellationToken);
                response.Result = flowExec;
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }

        private FlowExecution NewEntity(int idFlow)
        {
            return new FlowExecution()
            {
                IdFlow = idFlow,
                Active = true,
                CreatedBy = "user",
                CreatedOn = DateTime.Now,
                ModifiedBy = "user",
                ModifiedOn = DateTime.Now,
            };
        }
    }
}

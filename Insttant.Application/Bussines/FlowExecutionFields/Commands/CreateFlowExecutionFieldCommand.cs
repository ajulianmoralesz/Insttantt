using Insttant.DataAccess.Repositories;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowExecutionFields.Commands
{
    internal class CreateFlowExecutionFieldCommand : IRequest<Response<bool>>
    {
        public string Value { get; set; }
        public int IdFlowExecution { get; set; }
        public int IdFlowStepField { get; set; }

    }
    internal class CreateFlowExecutionFieldCommandHandler : IRequestHandler<CreateFlowExecutionFieldCommand, Response<bool>>
    {
        #region vars
        private readonly IRepository<FlowExecutionField> _flowExecFieldRepo;
        #endregion

        #region ctor
        public CreateFlowExecutionFieldCommandHandler(IRepository<FlowExecutionField> flowExecFieldRepo)
        {
            _flowExecFieldRepo = flowExecFieldRepo;
        }
        #endregion
        public async Task<Response<bool>> Handle(CreateFlowExecutionFieldCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            try
            {
                var exists = await _flowExecFieldRepo.GetByConditionsAsync(x=> x.IdFlowExecution == request.IdFlowExecution && x.IdFlowStepField == request.IdFlowStepField);
                if (!exists.Any())
                {
                    var entity = GetEntity(request);
                    _flowExecFieldRepo.Add(entity);
                    response.Result = await _flowExecFieldRepo.SaveAsync(cancellationToken);
                }
                else
                    response.Result = false;

            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }

        private FlowExecutionField GetEntity(CreateFlowExecutionFieldCommand command)
        {
            return new FlowExecutionField()
            {
                IdFlowExecution = command.IdFlowExecution,
                value = command.Value,
                IdFlowStepField = command.IdFlowStepField,
                Active = true,
                CreatedBy = "user",
                CreatedOn = DateTime.Now,
                ModifiedBy = "user",
                ModifiedOn = DateTime.Now,

            };
        }
    }


}

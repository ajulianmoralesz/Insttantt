using FluentValidation;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.FlowExecutions.Commands.Creates;
using Insttantt.Application.Bussines.FlowSteps.Queries;
using Insttantt.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowExecutions.Commands.Validators
{
    public class ExecuteFlowCommandValidator : AbstractValidator<ExecuteFlowCommand>
    {
        #region vars
        private readonly IRepository<Flow> _flowRepo;
        private readonly ISender _sender;
        #endregion

        #region ctor
        public ExecuteFlowCommandValidator(IRepository<Flow> flowRepo, ISender sender)
        {
            _flowRepo = flowRepo;
            _sender = sender;
            RuleFor(x => x.IdFlow)
                .GreaterThan(0)
                .WithMessage("the IdFlow field must be greater than zero {0}");

            RuleFor(x => x.IdExecution)
                .MustAsync(ExecutionExist)
                .When(x => x.IdExecution.HasValue && x.IdExecution > 0)
                .WithMessage("the IdExecution field must have an execution associated with it");

            RuleFor(x => x)
                .MustAsync(HavePendingSteps)
                .When(x=> x.IdFlow > 0)
                .WithMessage("The flow has already been fully executed. No steps available to run");
        }
        #endregion

        public async Task<bool> ExecutionExist(int? idExecution, CancellationToken cancellationToken)
        {
            var result = await _flowRepo.GetByConditionsAsync(x => x.Id == idExecution);
            return result.Any();
        }

        public async Task<bool> HavePendingSteps(ExecuteFlowCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetPendingStepsQuery() { IdExecution = command.IdExecution, IdFlow = command.IdFlow });
            return result.Result.Any();
        }
    }
}

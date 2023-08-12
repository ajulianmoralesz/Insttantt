using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.Flows.Commands.Creates.Models;
using Insttantt.Application.Bussines.FlowSteps.Commands.Creates;
using Insttantt.Application.Bussines.Weather.Queries;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using Insttantt.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Flows.Commands.Creates
{
    public class CreateFlowCommand : IRequest<Response<Flow>>
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<FlowStepInput> Steps { get; set; } = new List<FlowStepInput>();
    }

    public class CreateFlowCommandHandler : IRequestHandler<CreateFlowCommand, Response<Flow>>
    {
        #region vars
        private readonly IRepository<Flow> _flowRepo;
        private readonly ISender _sender;
        #endregion

        #region ctor
        public CreateFlowCommandHandler(IRepository<Flow> flowRepo, ISender sender)
        {
            _flowRepo = flowRepo;
            _sender = sender;
        }
        #endregion


        public async Task<Response<Flow>> Handle(CreateFlowCommand request, CancellationToken cancellationToken)
        {
            Response<Flow> response = new Response<Flow>();
            try
            {
                var flow = GetEntity(request);
                _flowRepo.Add(flow);
                await _flowRepo.SaveAsync(cancellationToken);
                response.Result = flow;
                await _sender.Send(new CreateFlowStepCommand() { IdFlow = flow.Id, FlowStepInputs = request.Steps });
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }

        private Flow GetEntity(CreateFlowCommand request)
        {
            return new Flow()
            {
                Name = request.Name,
                Description = request.Description,
                Active = true,
                CreatedBy = "user",
                CreatedOn = DateTime.Now,
                ModifiedBy = "user",
                ModifiedOn = DateTime.Now,
            };
        }
    }
}

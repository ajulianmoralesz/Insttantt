using AutoMapper;
using AutoMapper.QueryableExtensions;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.FlowStepFields.Queries;
using Insttantt.Application.Bussines.FlowSteps.Queries.DTO;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Application.Bussines.FlowSteps.Queries
{
    public class GetPendingStepsQuery : IRequest<Response<List<PendingStepDto>>>
    {
        public int IdFlow { get; set; }
        public int? IdExecution { get; set; }
    }

    public class GetPendingStepsQueryHandler : IRequestHandler<GetPendingStepsQuery, Response<List<PendingStepDto>>>
    {
        #region vars
        private readonly IRepository<FlowExecutionField> _flowExecRepo;
        private readonly IRepository<FlowStep> _flowStepRepo;
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        #endregion

        #region ctor
        public GetPendingStepsQueryHandler(IRepository<FlowExecutionField> flowExecRepo, IRepository<FlowStep> flowStepRepo, IMapper mapper, ISender sender)
        {
            _flowExecRepo = flowExecRepo;
            _flowStepRepo = flowStepRepo;
            _mapper = mapper;
            _sender = sender;
        }
        #endregion
        public async Task<Response<List<PendingStepDto>>> Handle(GetPendingStepsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<PendingStepDto>>();
            try
            {
                var executedSteps = new List<int>();
                if (request.IdExecution != null && request.IdExecution > 0)
                {
                    executedSteps.AddRange(await _flowExecRepo.GetAllActive()
                        .Include(x => x.FlowStepField)
                        .ThenInclude(x => x.FlowStep)
                        .Where(x => x.IdFlowExecution == request.IdExecution)
                        .Select(x => x.FlowStepField.FlowStep.Id).ToArrayAsync());
                }
                var pendingStep = await _flowStepRepo.GetAllActive()
                    .Include(x => x.Step)
                    .Where(x => x.IdFlow == request.IdFlow && !executedSteps.Contains(x.Id))
                    .ProjectTo<PendingStepDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                Parallel.ForEach(pendingStep, async pS =>
                {
                    pS.Fields = (await _sender.Send(new GetFlowStepFieldsQuery() { IdFlowStep = pS.Id })).Result;
                });
                response.Result = pendingStep;
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }
    }
}

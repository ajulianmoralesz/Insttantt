using AutoMapper;
using AutoMapper.QueryableExtensions;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.FlowExecutions.DTO;
using Insttantt.Application.Bussines.FlowSteps.Queries;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowExecutions.Queries
{
    public class GetExecutionsQuery : IRequest<Response<List<ExecutionDto>>>
    {
    }

    public class GetExecutionsQueryHandler : IRequestHandler<GetExecutionsQuery, Response<List<ExecutionDto>>>
    {
        #region vars
        private readonly IRepository<FlowExecution> _flowExecRepo;
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        #endregion

        #region ctor
        public GetExecutionsQueryHandler(IRepository<FlowExecution> flowExecRepo, IMapper mapper, ISender sender)
        {
            _flowExecRepo = flowExecRepo;
            _mapper = mapper;
            _sender = sender;
        }
        #endregion
        public async Task<Response<List<ExecutionDto>>> Handle(GetExecutionsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<ExecutionDto>>();
            try
            {
                var executions = await _flowExecRepo.GetAllActive()
                    .Include(x => x.Flow)
                    .ProjectTo<ExecutionDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                foreach (var x in executions) {
                    x.IsDone = !(await _sender.Send(new GetPendingStepsQuery() { IdFlow = x.IdFlow, IdExecution = x.Id })).Result.Any();
                }
                //Parallel.ForEach(executions, async x =>
                //{
                //    x.IsDone = !(await _sender.Send(new GetPendingStepsQuery() { IdFlow = x.IdFlow, IdExecution = x.Id })).Result.Any();
                //});
                response.Result = executions;
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }
    }
}

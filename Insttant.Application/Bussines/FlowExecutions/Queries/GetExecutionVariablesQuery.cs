using AutoMapper;
using AutoMapper.QueryableExtensions;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.FlowExecutions.Commands.Creates;
using Insttantt.Application.Bussines.FlowExecutions.DTO;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Application.Interfaces;
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
    public class GetExecutionVariablesQuery : IRequest<Response<List<ExecutionVariablesDto>>>
    {
        public int? IdExecution { get; set; }
    }
    public class GetExecutionVariablesQueryHandler : IRequestHandler<GetExecutionVariablesQuery, Response<List<ExecutionVariablesDto>>>
    {
        #region vars
        private readonly IRepository<FlowExecutionField> _flowExecRepo;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public GetExecutionVariablesQueryHandler(IRepository<FlowExecutionField> flowExecRepo, IMapper mapper)
        {
            _flowExecRepo = flowExecRepo;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<ExecutionVariablesDto>>> Handle(GetExecutionVariablesQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<ExecutionVariablesDto>>();
            try
            {
                if (request.IdExecution != null && request.IdExecution > 0)
                {
                    response.Result = await _flowExecRepo.GetAllActive()
                        .Include(x => x.FlowStepField)
                        .ThenInclude(x => x.Field)
                        .Where(x => x.IdFlowExecution == request.IdExecution)
                        .ProjectTo<ExecutionVariablesDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
                }
                else
                    response.Result = new List<ExecutionVariablesDto>();
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }
    }
}

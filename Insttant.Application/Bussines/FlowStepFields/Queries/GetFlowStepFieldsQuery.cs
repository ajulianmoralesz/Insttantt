using AutoMapper;
using AutoMapper.QueryableExtensions;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.FlowStepFields.DTO;
using Insttantt.Application.Bussines.FlowSteps.Queries;
using Insttantt.Application.Bussines.FlowSteps.Queries.DTO;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowStepFields.Queries
{
    public class GetFlowStepFieldsQuery : IRequest<Response<List<FlowStepFieldDto>>>
    {
        public int IdFlowStep { get; set; }
    }

    public class GetFlowStepFieldsQueryHandler : IRequestHandler<GetFlowStepFieldsQuery, Response<List<FlowStepFieldDto>>>
    {
        #region vars
        private readonly IRepository<FlowStepField> _flowStepFieldRepo;
        private readonly IMapper _mapper;
        #endregion
        #region ctor
        public GetFlowStepFieldsQueryHandler(IRepository<FlowStepField> flowStepFieldRepo, IMapper mapper)
        {
            _flowStepFieldRepo = flowStepFieldRepo;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<FlowStepFieldDto>>> Handle(GetFlowStepFieldsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<FlowStepFieldDto>>();
            try
            {
                response.Result = await _flowStepFieldRepo.GetAllActive()
                    .Include(x => x.Field)
                    .Where(x => x.IdFlowStep == request.IdFlowStep)
                    .ProjectTo<FlowStepFieldDto>(_mapper.ConfigurationProvider)                  
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }
    }


}

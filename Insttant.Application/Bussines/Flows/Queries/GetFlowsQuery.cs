using AutoMapper;
using AutoMapper.QueryableExtensions;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.Flows.DTO;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Application.Bussines.Flows.Queries
{
    public class GetFlowsQuery : IRequest<Response<List<FlowDto>>>
    {
    }

    public class GetFlowsQueryHandler : IRequestHandler<GetFlowsQuery, Response<List<FlowDto>>>
    {
        #region vars
        private readonly IRepository<Flow> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public GetFlowsQueryHandler(IRepository<Flow> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<FlowDto>>> Handle(GetFlowsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<FlowDto>>();
            try
            {
                response.Result = await _repository.GetAll()
                    .ProjectTo<FlowDto>(_mapper.ConfigurationProvider)
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

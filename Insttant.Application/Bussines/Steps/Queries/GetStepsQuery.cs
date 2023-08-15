using AutoMapper;
using AutoMapper.QueryableExtensions;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.Steps.DTO;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Application.Bussines.Steps.Queries
{
    public class GetStepsQuery : IRequest<Response<List<StepDto>>>
    {
    }

    public class GetStepsQueryHandler : IRequestHandler<GetStepsQuery, Response<List<StepDto>>>
    {
        #region vars
        private readonly IRepository<Step> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public GetStepsQueryHandler(IRepository<Step> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<StepDto>>> Handle(GetStepsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<StepDto>>();
            try
            {
                response.Result = await _repository.GetAll()
                    .ProjectTo<StepDto>(_mapper.ConfigurationProvider)
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

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.Fields.DTO;
using Insttantt.Application.Bussines.Weather.Queries;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using Insttantt.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Fields.Queries
{
    public class GetFieldsQuery : IRequest<Response<List<FieldDto>>>
    {
    }

    public class GetFieldsQueryHandler : IRequestHandler<GetFieldsQuery, Response<List<FieldDto>>>
    {
        #region vars
        private readonly IRepository<Field> _repository;
        private readonly IMapper _mapper;
        #endregion
        #region ctor
        public GetFieldsQueryHandler(IRepository<Field> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper= mapper;
        }
        #endregion
        public async Task<Response<List<FieldDto>>> Handle(GetFieldsQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<FieldDto>>();
            try
            {
                response.Result = await _repository.GetAll()
                    .ProjectTo<FieldDto>(_mapper.ConfigurationProvider)
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

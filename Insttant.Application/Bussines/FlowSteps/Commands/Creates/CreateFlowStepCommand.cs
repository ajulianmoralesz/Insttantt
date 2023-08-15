using Insttant.DataAccess.Repositories;
using Insttantt.Application.Bussines.Flows.Commands.Creates;
using Insttantt.Application.Bussines.Models;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowSteps.Commands.Creates
{
    public class CreateFlowStepCommand :  IRequest<Response<List<FlowStep>>>
    {
        public int IdFlow { get; set; }
        public List<FlowStepInput> FlowStepInputs { get; set; } = new List<FlowStepInput>();
    }

    public class CreteFlowStepCommandHandler : IRequestHandler<CreateFlowStepCommand, Response<List<FlowStep>>>
    {
        #region vars
        private readonly IRepository<FlowStep> _flowStepRepo;
        #endregion

        #region ctor
        public CreteFlowStepCommandHandler(IRepository<FlowStep> flowStepRepo)
        {
            _flowStepRepo = flowStepRepo;
        }
        #endregion
        public async Task<Response<List<FlowStep>>> Handle(CreateFlowStepCommand request, CancellationToken cancellationToken)
        {
            var response =  new Response<List<FlowStep>>();
            try
            {
                var entites = GetEntities(request);
                _flowStepRepo.AddRange(entites);
                await _flowStepRepo.SaveAsync(cancellationToken);
                response.Result = entites;
            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }

        private List<FlowStep> GetEntities(CreateFlowStepCommand request) 
        {
            List<FlowStepField> GetFields(FlowStepInput stepInput)
            {
                return stepInput.Fields.Select(x => new FlowStepField()
                {
                    IdField =  x.IdField,
                    IsOutput = x.IsOutput,
                    Active = true,
                    CreatedBy = "user",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "user",
                    ModifiedOn = DateTime.Now,
                }).ToList();
            }
            return request.FlowStepInputs.Select(x => new FlowStep()
            {
                IdFlow = request.IdFlow,
                IdStep = x.IdStep,
                Fields = GetFields(x),
                Active = true,
                CreatedBy = "user",
                CreatedOn = DateTime.Now,
                ModifiedBy = "user",
                ModifiedOn = DateTime.Now,
            }).ToList();

        }
    }

}

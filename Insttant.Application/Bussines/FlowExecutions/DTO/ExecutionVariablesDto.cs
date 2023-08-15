using AutoMapper;
using Insttantt.Application.Bussines.FlowStepFields.DTO;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowExecutions.DTO
{
    public class ExecutionVariablesDto : IMapFrom<FlowExecutionField>
    {
        public int Id { get; set; }
        public int IdFlowStepField { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FlowExecutionField, ExecutionVariablesDto>()
                .ForMember(x => x.Code, opt => opt.MapFrom(y => y.FlowStepField.Field.Code));
        }
    }
}

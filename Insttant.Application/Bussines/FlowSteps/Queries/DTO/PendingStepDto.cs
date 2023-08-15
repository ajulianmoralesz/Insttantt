using AutoMapper;
using Insttantt.Application.Bussines.FlowStepFields.DTO;
using Insttantt.Application.Bussines.Steps.DTO;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowSteps.Queries.DTO
{
    public class PendingStepDto : IMapFrom<FlowStep>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<FlowStepFieldDto> Fields { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FlowStep, PendingStepDto>()
                .ForMember(x => x.Code, opt => opt.MapFrom(y => y.Step.Code))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Step.Name))
                .ForMember(x => x.Url, opt => opt.MapFrom(y => y.Step.Url));
        }

    }
}

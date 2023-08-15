using AutoMapper;
using Insttantt.Application.Bussines.FlowSteps.Queries.DTO;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowStepFields.DTO
{
    public class FlowStepFieldDto : IMapFrom<FlowStepField>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsOutput { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FlowStepField, FlowStepFieldDto>()
                .ForMember(x => x.Code, opt => opt.MapFrom(y => y.Field.Code))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Field.Name));
        }

    }
}

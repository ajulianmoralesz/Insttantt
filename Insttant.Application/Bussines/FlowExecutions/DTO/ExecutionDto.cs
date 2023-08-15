using AutoMapper;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.FlowExecutions.DTO
{
    public class ExecutionDto : IMapFrom<FlowExecution>
    {
        public int Id { get; set; }
        public int IdFlow { get; set; }
        public string FlowName { get; set; }
        public string FlowDescription { get; set; }
        public bool IsDone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FlowExecution, ExecutionDto>()
                .ForMember(x => x.FlowName, opt => opt.MapFrom(y => y.Flow.Name))
                .ForMember(x => x.FlowDescription, opt => opt.MapFrom(y => y.Flow.Description));
        }
    }
}

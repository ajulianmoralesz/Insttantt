using AutoMapper;
using Insttantt.Application.Bussines.Fields.DTO;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Flows.DTO
{
    public class FlowDto : IMapFrom<Flow>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flow, FlowDto>();
        }
    }
}

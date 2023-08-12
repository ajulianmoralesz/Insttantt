using AutoMapper;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Steps.DTO
{
    public class StepDto : IMapFrom<Step>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Step, StepDto>();
        }
    }
}

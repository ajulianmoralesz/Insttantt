using AutoMapper;
using Insttantt.Application.Bussines.Steps.DTO;
using Insttantt.Application.Interfaces;
using Insttantt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Fields.DTO
{
    public class FieldDto : IMapFrom<Field>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Field, FieldDto>();
        }
    }
}

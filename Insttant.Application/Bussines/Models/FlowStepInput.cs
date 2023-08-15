using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Models
{
    public class FlowStepInput
    {
        public int IdStep { get; set; }
        public List<FlowStepFieldInput> Fields { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Flows.Commands.Creates.Models
{
    public class FlowStepFieldInput
    {
        public int IdField { get; set; }
        public bool IsOutput { get; set; }
        public string Value { get; set; }
    }
}

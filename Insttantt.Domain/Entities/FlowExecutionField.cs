using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public class FlowExecutionField : BaseEntity
    {
        public int IdFlowStepField { get; set; }
        public int IdFlowExecution { get; set; }
        public string value { get; set; } = "";
        public FlowExecution FlowExecution { get; set; }
        public FlowStepField FlowStepField { get; set; }
    }
}

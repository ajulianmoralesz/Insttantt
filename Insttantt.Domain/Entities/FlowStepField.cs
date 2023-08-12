using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public  class FlowStepField : BaseEntity
    {
        public int IdField { get; set; }
        public int IdFlowStep { get; set; }
        public string DefaultValue { get; set; } = "";
        public Field Field { get; set; }
        public FlowStep FlowStep { get; set; }
        public bool IsOutput { get; set; }
        public IList<FlowExecutionField> FlowExecutionFields { get; set; } = new List<FlowExecutionField>();
    }
}

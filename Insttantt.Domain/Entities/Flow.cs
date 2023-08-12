using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public class Flow : BaseEntity
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public IList<FlowStep> Steps { get; set; } = new List<FlowStep>();
        public IList<FlowExecution> Executions { get; set; } = new List<FlowExecution>();
    }
}

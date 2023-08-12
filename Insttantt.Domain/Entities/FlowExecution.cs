using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public class FlowExecution : BaseEntity
    {
        public int IdFlow { get; set; }
        public bool IsDone { get; set; }
        public Flow Flow { get; set; }
        public IList<FlowExecutionField> Fields { get; set; } = new List<FlowExecutionField>();
    }
}

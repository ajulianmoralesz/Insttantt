using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public class FlowStep : BaseEntity
    {
        public int IdStep { get; set; }
        public int IdFlow { get; set; }
        public Step Step { get; set; }
        public Flow Flow { get; set; }
        public IList<FlowStepField> Fields { get; set; } = new List<FlowStepField>();
    }
}

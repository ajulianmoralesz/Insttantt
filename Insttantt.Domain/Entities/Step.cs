using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public class Step : BaseEntity
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Url { get; set; } = "";
        public IList<FlowStep> FlowSteps { get; set; } = new List<FlowStep>();
    }
}

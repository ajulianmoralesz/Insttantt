using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public class Field : BaseEntity
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public IList<FlowStepField> FlowStepFields { get; set; } = new List<FlowStepField>();
        public IList<FieldOptionValue> fieldOptionValues { get; set; } = new List<FieldOptionValue>();

    }
}

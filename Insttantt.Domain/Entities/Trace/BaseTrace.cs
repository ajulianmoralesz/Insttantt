using Insttantt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities.Trace
{
    public abstract class BaseTrace
    {
        public string Method { get; set; } = "";
        public List<TraceProperty> Properties { get; set; }
        public long ExecutionTime { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

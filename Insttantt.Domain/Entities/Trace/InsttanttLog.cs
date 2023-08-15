using Insttantt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities.Trace
{
    public class InsttanttLog : BaseTrace
    {
        public string Message { get; set; } = "";
    }
}

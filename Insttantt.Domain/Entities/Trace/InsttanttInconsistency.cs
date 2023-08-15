using Insttantt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities.Trace
{
    public class InsttanttInconsistency : BaseTrace
    {
        public string ErrorMessage { get; set; }
    }
}

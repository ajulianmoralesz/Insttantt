using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Models
{
    public class FlowExecutionResponse
    {
        public int FlowExecutionId { get; set; }
        public int ExecutedSteps { get; set; }
        public int Succes { get; set; }
        public int Errors { get; set; }
    }
}

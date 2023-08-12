using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public class FieldOptionValue : BaseEntity
    {
        public int IdField { get; set; }
        public string Value { get; set; } = "";
        public Field Field { get; set; }
    }
}

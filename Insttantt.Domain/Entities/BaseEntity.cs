using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = "user";
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; } = "user";
        public DateTime? ModifiedOn { get; set; }
        public bool Active { get; set; } = true;
    }
}

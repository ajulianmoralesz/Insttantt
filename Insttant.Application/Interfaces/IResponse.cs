using Insttantt.Application.ServiceErrorHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Interfaces
{
    public interface IResponse<out T>
    {
        T Result { get; }
        ErrorServiceProvider ErrorProvider { get; set; }
    }
}

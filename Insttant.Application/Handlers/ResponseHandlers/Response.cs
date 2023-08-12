using Insttantt.Application.Interfaces;
using Insttantt.Application.ServiceErrorHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Handlers.ResponseHandlers
{
    public class Response<T> : IResponse<T>
    {
        public Response()
        {
            ErrorProvider = new();
        }
        public T Result { get; set; }
        public ErrorServiceProvider ErrorProvider { get; set; }

        public static implicit operator Response<T>(bool v)
        {
            throw new NotImplementedException();
        }
    }
}

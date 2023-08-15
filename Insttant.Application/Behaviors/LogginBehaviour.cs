using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Behaviors
{
    public  class LogginBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        //Inject Log and Inconsistencies Service
        private readonly Stopwatch _timer;
        public LogginBehaviour()
        {
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var message = string.Empty;
            Exception? exc = null;
            TResponse? response = default(TResponse);
            _timer.Start();
            try
            {
                response = await next();
                message = $"Request {requestName} is OK!";
            }
            catch (Exception ex)
            {
                exc = ex;
                message = $"Request {requestName} have unhadled exceptions : {ex.Message}!";
            }
            finally
            {                
                _timer.Stop();
                Console.WriteLine($"{message} : Elapse Time: {_timer.ElapsedMilliseconds}ms");
                if (exc != null)
                    throw exc;
            }
            return response;
        }
    }
}
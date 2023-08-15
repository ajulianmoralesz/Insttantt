using Insttantt.DataAccess.Repositories;
using Insttantt.Domain.Entities.Trace;
using Insttantt.Domain.Models;
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
        private readonly IMongoRepository<InsttanttLog> _logRepository;
        private readonly IMongoRepository<InsttanttInconsistency> _inconsistencyRepository;
        public LogginBehaviour(IMongoRepository<InsttanttLog> logRepository, IMongoRepository<InsttanttInconsistency> inconsistencyRepository)
        {
            _timer = new Stopwatch();
            _logRepository = logRepository;
            _inconsistencyRepository = inconsistencyRepository;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var properties = typeof(TRequest).GetProperties().Select(x=> new TraceProperty { Name = x.Name, Value = Convert.ToString(x.GetValue(request))}).ToList();
            Exception? exc = null;
            TResponse? response = default(TResponse);
            _timer.Start();
            try
            {
                response = await next();
            }
            catch (Exception ex)
            {
                exc = ex;
            }
            finally
            {                
                _timer.Stop();
                if (exc != null)
                {
                    await _inconsistencyRepository.Insert(new InsttanttInconsistency() { ErrorMessage = exc.Message, ExecutionTime = _timer.ElapsedMilliseconds, Method = requestName, Properties = properties });
                    throw exc;
                }                    
                else
                {
                    await _logRepository.Insert(new InsttanttLog() { Message = "Request is OK!", ExecutionTime = _timer.ElapsedMilliseconds, Method = requestName, Properties = properties });
                }
            }
            return response;
        }
    }
}